using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace crm_app.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdressDtoForInsertion,Adress>();
            CreateMap<CompanyDtoForInsertion,Company>();
            CreateMap<CompanyDtoForUpdate,Company>().ReverseMap();
            CreateMap<PaymentDtoForCreation,Payment>();
        }
    }
}