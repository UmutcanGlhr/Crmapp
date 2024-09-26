using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class AdressRepository : RepositoryBase<Adress>, IAdressRepository
    {
        public AdressRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateAddress(Adress adress) => Create(adress);


        public void DeletenOneAddress(Adress adress)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Adress> GetAllAddress(string? id)
        {
            return _context.Adress.Where(c => c.userId == id);
        }

        public Adress? GetOneAddress(int id, bool trackChanges)
        {
             return FindByCondition(p => p.AddressID.Equals(id), trackChanges);
        }

    }
}