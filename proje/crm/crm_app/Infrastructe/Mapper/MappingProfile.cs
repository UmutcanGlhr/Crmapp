using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace crm_app.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PaymentDtoForCreation, Payment>();
            CreateMap<ProductDtoForInsertion, Product>();
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();
            CreateMap<siteSettingsDtoForUpdate, SiteSettings>().ReverseMap();
        }
    }
}   