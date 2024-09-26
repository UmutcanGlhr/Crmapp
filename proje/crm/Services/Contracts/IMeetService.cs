using Entities.Models;

namespace Services.Contracts
{
    public interface IMeetService
    {
        IEnumerable<Meet> GetAllMeet(bool trackChanges);

        void CreateMeet(Meet meet);

        IEnumerable<Meet> getMeet(string? id);
        IEnumerable<Meet> PastMeets(string? id);

        void Complete(int id);
    }
}