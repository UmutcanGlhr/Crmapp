using crm_app.Models;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _manager;

        public HomeController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Randevu BUL";
            var products = _manager.ProductService.GetAllProduct(false);
            var siteSetting = _manager.siteService.GetSettings(false);
            var users = _manager.AuthService.GetAllUsers().Where(c => c.aktive == true && c.ShowCase == true);
            var contact = new Contact(); // Boş bir contact formu
            var model = new HomePageViewModel
            {
                siteSettings = siteSetting,
                Products = products,
                Contact = contact,
                appUsers =users
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _manager.ContactService.CreateContact(contact);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}