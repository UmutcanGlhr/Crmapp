using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;

        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.CategoryService.GetAllCategory(false);
            return View(model);
        }
        public IActionResult categoryCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult categoryCreate([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                _manager.CategoryService.create(category);
                return RedirectToAction("Index");
                
            }
            return View();
        }
    }
}