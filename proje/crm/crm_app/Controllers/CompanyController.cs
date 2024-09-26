using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IServiceManager _serviceManager;
        

        public CompanyController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var model = _serviceManager.CompanyService.GetAllCompany(false);
            ViewData["Title"] = "Firmalar";
            return View(model);
        }
    }
}