using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        IQueryable<Company> GetCompany(string? id);

        void UpdateOneCompany(Company entity);

          IQueryable<Company> GetAllCompany(bool trackChanges);
    }
}