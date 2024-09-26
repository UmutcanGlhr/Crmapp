using Entities.Models;

namespace Repositories.Contracts
{
    public interface IMeetRepository : IRepositoryBase<Meet>
    {
        IQueryable<Meet> GetAllMeet(bool trackChanges);

        IQueryable<Meet> getMeet(string? id);
        IQueryable<Meet> PastMeets(string? id);
        void CreateMeet(Meet meet);

        void Complete(int id);

    }
}