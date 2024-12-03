using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private readonly IServiceManager _manager;

        public SettingsController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var settings = _manager.siteService.GetSettings(false);
            return View(settings);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([FromForm] siteSettingsDtoForUpdate siteSettingsDto, IFormFile file1, IFormFile file2,
        IFormFile file3, IFormFile file4)
        {
           
            
                // Mevcut ayarları al
                var existingSettings = _manager.siteService.GetSettings(false);

                // Dosya1 için kontrol
                if (file1 != null && file1.Length > 0)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file1.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file1.CopyToAsync(stream);
                    }
                    siteSettingsDto.ImgUrl = String.Concat("/images/", file1.FileName);
                }
                else
                {
                    // Dosya yüklenmediyse mevcut URL'yi koru
                    siteSettingsDto.ImgUrl = existingSettings.ImgUrl;
                }

                // Dosya2 için kontrol
                if (file2 != null && file2.Length > 0)
                {
                    string path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file2.FileName);
                    using (var stream2 = new FileStream(path2, FileMode.Create))
                    {
                        await file2.CopyToAsync(stream2);
                    }
                    siteSettingsDto.ImgUrl2 = String.Concat("/images/", file2.FileName);
                }
                else
                {
                    siteSettingsDto.ImgUrl2 = existingSettings.ImgUrl2; // mevcut URL'yi koru
                }

                // Dosya3 için kontrol
                if (file3 != null && file3.Length > 0)
                {
                    string path3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file3.FileName);
                    using (var stream3 = new FileStream(path3, FileMode.Create))
                    {
                        await file3.CopyToAsync(stream3);
                    }
                    siteSettingsDto.ImgUrl3 = String.Concat("/images/", file3.FileName);
                }
                else
                {
                    siteSettingsDto.ImgUrl3 = existingSettings.ImgUrl3; // mevcut URL'yi koru
                }

                // Dosya4 için kontrol
                if (file4 != null && file4.Length > 0)
                {
                    string path4 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file4.FileName);
                    using (var stream4 = new FileStream(path4, FileMode.Create))
                    {
                        await file4.CopyToAsync(stream4);
                    }
                    siteSettingsDto.ImgUrl4 = String.Concat("/images/", file4.FileName);
                }
                else
                {
                    siteSettingsDto.ImgUrl4 = existingSettings.ImgUrl4; // mevcut URL'yi koru
                }

                // Güncellenmiş ayarları veritabanında kaydet
                _manager.siteService.UpdateSettings(siteSettingsDto);
                return RedirectToAction("Index", "Dashboard");
            
            
        }
    }
}