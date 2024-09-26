using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {
        }

        public IQueryable<Company> GetAllCompany(bool trackChanges) => FindAll(trackChanges);


        public IQueryable<Company> GetCompany(string? id)
        {
            return _context.companies.Where(c => c.userId == id).Include(c => c.category);
        }

        public void UpdateOneCompany(Company entity) => Update(entity);

    }
}