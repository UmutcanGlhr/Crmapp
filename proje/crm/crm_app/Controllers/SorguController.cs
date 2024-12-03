using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Controllers
{
    public class SorguController : Controller
    {
        private readonly IServiceManager _manager;

        public SorguController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var meet = new Meet();
            return View(meet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] String sorguKodu)
        {
            var model = _manager.MeetService.SorguKodu(sorguKodu);
            return View(model);
        }
    }
}