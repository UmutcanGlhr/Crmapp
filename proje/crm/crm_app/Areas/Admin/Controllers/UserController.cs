using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> inactive([FromRoute(Name = "id")] string id)
        {
            await _manager.AuthService.userInActive(id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> onshowcase([FromRoute(Name = "id")] string id)
        {
            await _manager.AuthService.OnShowCase(id);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> closeShowCase([FromRoute(Name = "id")] string id)
        {
            await _manager.AuthService.closeShowCase(id);

            return RedirectToAction("Index");
        }
    }
}