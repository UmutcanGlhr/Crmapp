using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private IServiceManager _manager;

        public DashboardController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Admin";
            return View();
        }
        public List<DateTime> GetTimeSlotsForToday(DateTime date)
        {
            List<DateTime> timeSlots = new List<DateTime>();
            DateTime start = date.Date.AddHours(9);  // 09:00
            DateTime end = date.Date.AddHours(18).AddMinutes(30);  // 18:30

            while (start <= end)
            {
                timeSlots.Add(start);
                start = start.AddMinutes(30); // 30 dakikalık aralıklarla zaman dilimlerini ekle
            }

            return timeSlots;
        }

        public IActionResult CreateAppointmentsForAllUsers()
        {
            DateTime appointmentDate = DateTime.Today.AddDays(15);

            // Tüm kullanıcıları al
            var allUsers = _manager.AuthService.GetAllUsers().ToList();
            List<DateTime> timeSlots = GetTimeSlotsForToday(appointmentDate);
            // Her kullanıcı için randevu oluştur
            foreach (var user in allUsers)
            {
                // Kullanıcının o gün randevusu olup olmadığını kontrol et
                var hasAppointment = _manager.MeetService.GetAllMeetSlots(false)
                    .Any(slot => slot.userID == user.Id && slot.Date == appointmentDate.ToString("yyyy-MM-dd"));

                // Eğer randevu yoksa, yeni randevular oluştur
                if (!hasAppointment)
                {
                    // Bugünkü zaman dilimlerini al


                    foreach (var timeSlot in timeSlots)
                    {
                        // Kullanıcıya randevu oluştur
                        var meetSlot = new MeetSlot
                        {
                            Date = timeSlot.ToString("yyyy-MM-dd"),  // Tarih bilgisi
                            Time = timeSlot.ToString("HH:mm"),       // Saat bilgisi
                            IsBooked = false,                       // İlk başta boş olarak atanır
                            userID = user.Id,                        // Kullanıcıya atanır
                            user = user
                        };

                        // Veritabanına kaydet
                        _manager.MeetService.CreateMeetSlot(meetSlot);
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult deletePastMeetSlot()
        {
            _manager.MeetService.DeletePastMeet();    
            return RedirectToAction("Index");
        }
    }
}