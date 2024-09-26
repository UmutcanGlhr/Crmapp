using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IMeetRepository _meetRepository;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IAdressRepository _adressRepository;

        private readonly ICompanyRepository _companyRepository;

        private readonly IProductRepository _productRepository;

        private readonly IOrderRepositoy _orderRepositoy;

        private readonly IPaymentRepository _paymentRepository;
        public RepositoryManager(IMeetRepository meetRepository, RepositoryContext context, ICategoryRepository categoryRepository, IAdressRepository adressRepository, ICompanyRepository companyRepository, IProductRepository productRepository, IOrderRepositoy orderRepositoy, IPaymentRepository paymentRepository)
        {
            _meetRepository = meetRepository;
            _context = context;
            _categoryRepository = categoryRepository;
            _adressRepository = adressRepository;
            _companyRepository = companyRepository;
            _productRepository = productRepository;
            _orderRepositoy = orderRepositoy;
            _paymentRepository = paymentRepository;
        }

        public IMeetRepository Meet => _meetRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IAdressRepository Adress => _adressRepository;

        public ICompanyRepository Company => _companyRepository;

        public Contracts.IProductRepository Product =>  _productRepository;

        public IOrderRepositoy Order =>_orderRepositoy;

        public IPaymentRepository Payment => _paymentRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}