using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Components
{
    public class ActiveUserViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public ActiveUserViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.AuthService.GetAllUsers().Where(c => c.aktive == true).Count().ToString();

        }
    }
}