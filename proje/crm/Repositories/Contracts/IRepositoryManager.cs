namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IMeetRepository Meet {get;}
        ICategoryRepository Category{get;}

        IAdressRepository Adress{get;}

        ICompanyRepository Company{get;}

        IProductRepository Product{get;}
        IOrderRepositoy Order{get;}

        IPaymentRepository Payment{get;}

        void Save();
    }
}