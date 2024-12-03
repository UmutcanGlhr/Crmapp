using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.Components
{
    public class PriceSummaryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;

        public PriceSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }

        public string Invoke()
        {
            var model = _manager.PaymentService.GetAllPayment(false);
            decimal? totalprice = 0;
            decimal price = 0;
            foreach (var prc in model)
            {
                price = Convert.ToDecimal(prc.Amount);
                totalprice = totalprice+price;
            }
            return totalprice.ToString();
        }
    }
}