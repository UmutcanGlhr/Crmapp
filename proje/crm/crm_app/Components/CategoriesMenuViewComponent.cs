using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public CategoriesMenuViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public IViewComponentResult Invoke()
        {
            var categories =_manager.CategoryService.GetAllCategory(false);
            return View(categories);
        }
    }
}