using Entities.Models;

namespace Repositories.Contracts
{
    public interface IAdressRepository : IRepositoryBase<Adress>
    {
        void CreateAddress(Adress adress);
        void DeletenOneAddress(Adress adress);
        IQueryable<Adress> GetAllAddress(string? id);
        Adress? GetOneAddress(int id, bool trackChanges);
        
    }
}