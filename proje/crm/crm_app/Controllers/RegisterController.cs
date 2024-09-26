using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace crm_app
{
    public class RegisterController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IServiceManager _manager;

        public RegisterController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IServiceManager manager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _manager = manager;
        }

        private SelectList GetCategoriesSelectList()
        {
            return new SelectList(_manager.CategoryService.GetAllCategory(false), "CategoryID", "CategoryName", "1");
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Kayit ol";
            ViewBag.Categories = GetCategoriesSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Index([FromForm] RegisterDto model)
        {
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };

            var result = await _userManager
                .CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                var roleResult = await _userManager
               .AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else
            {
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View();
        }

       

    }
}