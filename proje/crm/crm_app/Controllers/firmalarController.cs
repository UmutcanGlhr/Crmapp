using crm_app.Models;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace crm_app.Controllers
{
    public class firmalarController : Controller
    {
        private readonly IServiceManager _manager;
        private readonly UserManager<AppUser> _userManager;

        public firmalarController(IServiceManager manager, UserManager<AppUser> userManager)
        {
            _manager = manager;
            _userManager = userManager;
        }

        private SelectList GetDateSelectList()
        {
            return new SelectList(_manager.MeetService.GetAllMeetSlots(false).GroupBy(ms => ms.Date).Select(g => g.First()).ToList()
            , "Id", "Date");
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Firmalar";
            var model = _manager.AuthService.GetAllUsers().Where(C => C.aktive == true);
            return View(model);
        }
        public async Task<IActionResult> get([FromRoute(Name = "id")] string username, DateTime? selectedDate)
        {
            ViewData["Title"] = username;
            var model = await _userManager.FindByNameAsync(username);
            var meet = _manager.MeetService.GetMeetSlot(false, model.Id);
            ViewBag.DateSelectlist = GetDateSelectList();

            if (selectedDate.HasValue)
            {
                meet = meet.Where(m => DateTime.Parse(m.Date).Date == selectedDate.Value.Date).ToList();
            }
            var result = new RandevuViewModel
            {
                MeetSlots = meet,
                User = model,
                SelectedDate = selectedDate  // Seçilen tarihi view'a gönder
            };
            return View(result);
        }
        public IActionResult ConfigureMeeting([FromRoute(Name = "id")] int id)
        {
            ViewData["Title"] = "Randevu Oluşturma";
            var result = _manager.MeetService.GetMeeting(id, false);
            var meeting = new Meet();
            var model = new MeetPageModel()
            {
                meetSlot = result,
                meet = meeting
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfigureMeeting([FromForm] Meet meet)
        {

            if (ModelState.IsValid)
            {
                string sorguKodu = GenerateRandomCode(11);
                meet.sorguKodu = sorguKodu;
                _manager.MeetService.CreateMeet(meet);
                _manager.MeetService.UpdateMeetSlot(meet.MeetSlotID);
                return RedirectToAction("kayit", new { randevuKodu = sorguKodu });
            }
            return View();
        }

        public IActionResult kategori([FromRoute(Name = "id")] string name)
        {
            var category = _manager.CategoryService.GetAllCategory(false)
                   .FirstOrDefault(c => c.CategoryName == name);

            if (category == null)
            {
                // Kategori bulunamadığında bir hata sayfasına yönlendirebilir veya hata mesajı döndürebilirsiniz
                return NotFound(); // ya da uygun bir hata sayfası döndürün
            }

            // Bulunan kategori ID'sine göre kullanıcıları filtrele
            var model = _manager.AuthService.GetAllUsers()
                          .Where(u => u.categoryID == category.CategoryID).ToList();

            return View(model);
        }


        private string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; // Harf ve rakamlar
            var random = new Random();
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = chars[random.Next(chars.Length)];
            }

            return new string(result);
        }

        public IActionResult kayit(string randevuKodu)
        {
            return View((object)randevuKodu);
        }
    }
}