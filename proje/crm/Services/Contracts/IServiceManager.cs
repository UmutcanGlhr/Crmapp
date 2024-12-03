namespace Services.Contracts
{
    public interface IServiceManager
    {
        IMeetService MeetService{get;}
        ICategoryService CategoryService{get;}
        IAuthService AuthService{get;}
        IProductService ProductService{get;}
        IPaymentService PaymentService{get;}
        IContactService ContactService{get;}
        ISiteService siteService{get;}
    }
}