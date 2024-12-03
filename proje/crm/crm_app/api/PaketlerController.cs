using System.ComponentModel.DataAnnotations;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Model.V2;
using Iyzipay.Model.V2.Subscription;
using Iyzipay.Request;
using Iyzipay.Request.V2.Subscription;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace crm_app.api
{
    [Route("api/paketler")]
    [ApiController]
    public class PaketlerController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public PaketlerController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult paketler()
        {
            var model = _manager.ProductService.GetAllProduct(false);
            return Ok(model);
        }

    }
}