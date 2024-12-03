using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;
        private readonly IMeetRepository _meetRepository;

        private readonly ICategoryRepository _categoryRepository;

        private readonly IProductRepository _productRepository;

        private readonly IPaymentRepository _paymentRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMeetSlotRepository _meetSlotRepository;

        private readonly ISiteSettingsRepository _siteSettingsRepository;
        public RepositoryManager(IMeetRepository meetRepository, RepositoryContext context, ICategoryRepository categoryRepository, IProductRepository productRepository, IPaymentRepository paymentRepository, IContactRepository contactRepository, IMeetSlotRepository meetSlotRepository, ISiteSettingsRepository siteSettingsRepository)
        {
            _meetRepository = meetRepository;
            _context = context;
            _categoryRepository = categoryRepository;

            _productRepository = productRepository;
            _paymentRepository = paymentRepository;
            _contactRepository = contactRepository;
            _meetSlotRepository = meetSlotRepository;
            _siteSettingsRepository = siteSettingsRepository;
        }

        public IMeetRepository Meet => _meetRepository;

        public ICategoryRepository Category => _categoryRepository;


        public IProductRepository Product =>  _productRepository;

        public IPaymentRepository Payment => _paymentRepository;

        public IContactRepository Contact => _contactRepository;

        public IMeetSlotRepository MeetSlot =>_meetSlotRepository;

        public ISiteSettingsRepository settingsRepository => _siteSettingsRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}