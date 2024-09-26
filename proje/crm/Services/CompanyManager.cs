using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CompanyManager : ICompanyService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public CompanyManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }


        public void CreateSettings(CompanyDtoForInsertion companyDto)
        {
            Company company = _mapper.Map<Company>(companyDto);
            _manager.Company.Create(company);
            _manager.Save();
        }

        public IEnumerable<Company> GetAllCompany(bool trackChanges)
        {
            return _manager.Company.GetAllCompany(trackChanges);
        }

        public IEnumerable<Company> GetCompany(string? id)
        {
            return _manager.Company.GetCompany(id);
        }

        public CompanyDtoForUpdate GetOneCompanyForUpdate(string? id, bool trackChanges)
        {
            var company = GetCompany(id).FirstOrDefault();
            var companyDto = _mapper.Map<CompanyDtoForUpdate>(company);
            return companyDto;
        }

        public void UpdateOneCompany(CompanyDtoForUpdate companyDto)
        {
            var entity = _mapper.Map<Company>(companyDto);
            _manager.Company.UpdateOneCompany(entity);
            _manager.Save();
        }
    }
}