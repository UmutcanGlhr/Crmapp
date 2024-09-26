namespace Services.Contracts
{
    public interface IServiceManager
    {
        IMeetService MeetService{get;}
        ICategoryService CategoryService{get;}

        IAuthService AuthService{get;}

        IAdressService AdressService{get;}

        ICompanyService CompanyService{get;}

        IProductService ProductService{get;}

        IOrderService OrderService{get;}
         
        IPaymentService PaymentService{get;}
    }
}