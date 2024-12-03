using crm_app.Models;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace crm_app.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IServiceManager _manager;

        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, IServiceManager manager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _manager = manager;
            _signInManager = signInManager;
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategory(false), "CategoryID", "CategoryName", "1");
        }

        public IActionResult Register()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] AppUserRegisterDto appUserRegisterDto, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                List<string> images = new List<string>();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var username = appUserRegisterDto.FirmaAdi?.Replace(" ", "");
                AppUser appUser = new AppUser()
                {
                    FirmaAdi = appUserRegisterDto.FirmaAdi,
                    UserName = username,
                    VergiNo = appUserRegisterDto.VergiNo,
                    VergiDairesi = appUserRegisterDto.VergiDairesi,
                    Şehir = appUserRegisterDto.Şehir,
                    İlçe = appUserRegisterDto.İlçe,
                    TamAdres = appUserRegisterDto.TamAdres,
                    categoryID = appUserRegisterDto.categoryID,
                    Email = appUserRegisterDto.Email,
                    PhoneNumber = appUserRegisterDto.PhoneNumber,
                    FirmaLogo = String.Concat("/images/", file.FileName)
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

                if (result.Succeeded)
                {

                    var roleResult = await _userManager
                   .AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        CreateAutomaticAppointments(appUser.Id);
                        return RedirectToAction("Login", "Account");
                    }

                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                  
                }
                ModelState.AddModelError("Error", "Şifrelerde en az bir alfanümerik olmayan karakter bulunmalıdır.");
            }
            return View();
        }

        public IActionResult UserRegister()
        {
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> UserRegister([FromForm] AppUserRegisterDto appUserRegisterDto, IFormFile file)
        {

            if (ModelState.IsValid)
            {
                ServiceKPSPublic service = new ServiceKPSPublic();
                Response response = new Response();
                response._parametters.TcKimlikNo = long.Parse(appUserRegisterDto.TcKimlik);
                response._parametters.Ad = appUserRegisterDto.AD;
                response._parametters.SoyAd = appUserRegisterDto.SOYAD;
                response._parametters.dogumyili = appUserRegisterDto.DogumYili;
                var res = service.OnGetService(response._parametters);
                if (res.Result == true)
                {
                    List<string> images = new List<string>();
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    var username = (appUserRegisterDto.AD + appUserRegisterDto.SOYAD).Replace(" ", "");
                    AppUser appUser = new AppUser()
                    {
                        AD = appUserRegisterDto.AD,
                        SOYAD = appUserRegisterDto.SOYAD,
                        UserName = username,
                        DogumYili = appUserRegisterDto.DogumYili,
                        FirmaAdi = appUserRegisterDto.AD + " " + appUserRegisterDto.SOYAD,
                        TcKimlik = appUserRegisterDto.TcKimlik,
                        Şehir = appUserRegisterDto.Şehir,
                        İlçe = appUserRegisterDto.İlçe,
                        TamAdres = appUserRegisterDto.TamAdres,
                        categoryID = appUserRegisterDto.categoryID,
                        Email = appUserRegisterDto.Email,
                        PhoneNumber = appUserRegisterDto.PhoneNumber,
                        FirmaLogo = String.Concat("/images/", file.FileName)
                    };
                    var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

                    if (result.Succeeded)
                    {

                        var roleResult = await _userManager
                       .AddToRoleAsync(appUser, "User");
                        if (roleResult.Succeeded)
                        {
                            CreateAutomaticAppointments(appUser.Id);
                            return RedirectToAction("Login", "Account");
                        }

                    }
                    else
                    {
                        foreach (var err in result.Errors)
                        {
                            ModelState.AddModelError("", err.Description);
                        }
                    }

                }
                else
                {
                    ModelState.AddModelError("Error", "Hatalı TC Kimlik");
                }
                 ModelState.AddModelError("Error", "Şifrelerde en az bir alfanümerik olmayan karakter bulunmalıdır ve Paralonız en az 6 haneli olmalıdır.");
            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {

                AppUser? user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                        }
                        return RedirectToAction("Index", "Profile");
                    }
                }
                ModelState.AddModelError("Error", "Şifre veya E-Posta Adresi Hatalı");
            }
            return View();
        }

        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(ReturnUrl);
        }
        private void CreateAutomaticAppointments(string userId)
        {
            DateTime startDate = DateTime.Today; // Bugün
            int numberOfDays = 15; // Oluşturulacak gün sayısı

            for (int i = 0; i < numberOfDays; i++)
            {
                DateTime appointmentDate = startDate.AddDays(i);
                List<DateTime> timeSlots = GetTimeSlotsForDate(appointmentDate);

                foreach (var timeSlot in timeSlots)
                {
                    var meetSlot = new MeetSlot
                    {
                        Date = appointmentDate.ToString("yyyy-MM-dd"), // Tarih bilgisi
                        Time = timeSlot.ToString("HH:mm"), // Saat bilgisi
                        IsBooked = false, // İlk başta boş olarak atanır
                        userID = userId // Kullanıcı ID'si
                    };

                    // Randevuyu veritabanına ekle
                    _manager.MeetService.CreateMeetSlot(meetSlot);
                }
            }
        }

        private List<DateTime> GetTimeSlotsForDate(DateTime date)
        {
            List<DateTime> timeSlots = new List<DateTime>();
            DateTime start = date.Date.AddHours(9); // 09:00
            DateTime end = date.Date.AddHours(18); // 18:00

            while (start <= end)
            {
                timeSlots.Add(start);
                start = start.AddMinutes(30); // 30 dakikalık aralıklarla zaman dilimlerini ekle
            }

            return timeSlots;
        }


        public IActionResult AccessDenied([FromQuery(Name = "ReturnUrl")] string url)
        {
            return View();
        }
    }
}