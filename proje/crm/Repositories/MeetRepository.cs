using Entities.Models;
using Repositories.Contracts;


namespace Repositories
{
    public class MeetRepository : RepositoryBase<Meet>, IMeetRepository
    {
        public MeetRepository(RepositoryContext context) : base(context)
        {
        }

        public void Complete(int id)
        {
            var meet = FindByCondition(m => m.meetID.Equals(id), true);
            if (meet is null)
            {
                throw new Exception("Order could not found!");
            }
            meet.active = false;
        }

        public void CreateMeet(Meet meet) => Create(meet);


        public IQueryable<Meet> GetAllMeet(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Meet> getMeet(string? id)
        {
            return _context.meets.Where(c => c.userID == id && c.active == true);
        }

        public IQueryable<Meet> PastMeets(string? id)
        {
            return _context.meets.Where(c => c.userID == id && c.active == false);
        }
    }
}