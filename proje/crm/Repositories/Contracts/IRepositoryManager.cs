namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IMeetRepository Meet {get;}
        ICategoryRepository Category{get;}

        IProductRepository Product{get;}

        IPaymentRepository Payment{get;}

        IContactRepository Contact{get;}

        IMeetSlotRepository MeetSlot{get;}
        ISiteSettingsRepository settingsRepository{get;}

        void Save();
    }
}