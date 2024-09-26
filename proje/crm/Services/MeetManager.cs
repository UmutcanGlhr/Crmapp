using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class MeetManager : IMeetService
    {
        private readonly IRepositoryManager _manager;

        public MeetManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void Complete(int id)
        {
            _manager.Meet.Complete(id);
            _manager.Save();
        }

        public void CreateMeet(Meet meet)
        {
            _manager.Meet.Create(meet);
            _manager.Save();
        }

        public IEnumerable<Meet> GetAllMeet(bool trackChanges)
        {
            return _manager.Meet.GetAllMeet(trackChanges);
        }

        public IEnumerable<Meet> getMeet(string? id)
        {
            return _manager.Meet.getMeet(id);
        }

        public IEnumerable<Meet> PastMeets(string? id)
        {
            return _manager.Meet.PastMeets(id);
        }
    }
}