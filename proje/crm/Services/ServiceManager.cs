using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IMeetService _meetService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthService _authService;

        private readonly IProductService _productService;

        private readonly IPaymentService _paymentService;
        private readonly IContactService _contactService;
        private readonly ISiteService _siteService;
        public ServiceManager(IMeetService meetService, ICategoryService categoryService, IAuthService authService, IProductService productService, IPaymentService paymentService, IContactService contactService, ISiteService siteService)
        {
            _meetService = meetService;
            _categoryService = categoryService;
            _authService = authService;

            _productService = productService;
            _paymentService = paymentService;
            _contactService = contactService;
            _siteService = siteService;
        }

        public IMeetService MeetService => _meetService;

        public ICategoryService CategoryService => _categoryService;

        public IAuthService AuthService => _authService;

        public IProductService ProductService => _productService;

        public IPaymentService PaymentService => _paymentService;

        public IContactService ContactService => _contactService;

        public ISiteService siteService => _siteService;
    }
}