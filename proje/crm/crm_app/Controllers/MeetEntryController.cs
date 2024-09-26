using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Contracts;
using Services.Contracts;

namespace crm_app.Controllers
{
    public class MeetEntryController : Controller
    {
        private readonly IServiceManager _manager;


        public MeetEntryController(IServiceManager manager)
        {
            _manager = manager;
        }


        private SelectList GetCompanySelectList()
        {
            var allusers =_manager.AuthService.GetAllUsers();
            var filteredUsers =  allusers.Where(u => u.UserName != "Admin").ToList();
            return new SelectList(filteredUsers,"Id", "UserName", "1"); 
            //return new SelectList(_manager.AuthService.GetAllUsers(), "Id", "UserName", "1");
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Randevu Al";
            ViewBag.Componies = GetCompanySelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([FromForm] Meet meet)
        {
            if (ModelState.IsValid)
            {
                _manager.MeetService.CreateMeet(meet);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }


    }
}