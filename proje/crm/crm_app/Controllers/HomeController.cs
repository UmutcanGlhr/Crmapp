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
            var model = _manager.CompanyService.GetAllCompany(false);
            ViewData["Title"] = "Anasayfa";
            return View(model);
        }
    }
}