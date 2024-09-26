using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface ICompanyService
    {
        void CreateSettings(CompanyDtoForInsertion companyDto);

        IEnumerable<Company> GetAllCompany(bool trackChanges);
        
        IEnumerable<Company> GetCompany(string? id);

        CompanyDtoForUpdate GetOneCompanyForUpdate(string? id, bool trackChanges);
        void UpdateOneCompany(CompanyDtoForUpdate companyDto);
    }
}