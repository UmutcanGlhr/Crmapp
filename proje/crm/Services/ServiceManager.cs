using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IMeetService _meetService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthService _authService;
        private readonly IAdressService _adressService;
        private readonly ICompanyService _companyService;

        private readonly IProductService _productService;

        private readonly IOrderService _orderService;

        private readonly IPaymentService _paymentService;
        public ServiceManager(IMeetService meetService, ICategoryService categoryService, IAuthService authService, IAdressService adressService, ICompanyService companyService, IProductService productService, IOrderService orderService, IPaymentService paymentService)
        {
            _meetService = meetService;
            _categoryService = categoryService;
            _authService = authService;
            _adressService = adressService;
            _companyService = companyService;
            _productService = productService;
            _orderService = orderService;
            _paymentService = paymentService;
        }

        public IMeetService MeetService => _meetService;

        public ICategoryService CategoryService => _categoryService;

        public IAuthService AuthService => _authService;

        public IAdressService AdressService => _adressService;

        public ICompanyService CompanyService => _companyService;

        public IProductService ProductService => _productService;

        public IOrderService OrderService => _orderService;

        public IPaymentService PaymentService => _paymentService;
    }
}