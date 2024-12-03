using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Components
{
    public class PaymentViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public PaymentViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            return _manager.PaymentService.GetAllPayment(false).Count().ToString();

        }
    }
}