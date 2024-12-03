using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class MeetSlotRepository : RepositoryBase<MeetSlot>, IMeetSlotRepository
    {
        public MeetSlotRepository(RepositoryContext context) : base(context)
        {
        }

        public void deleteMeet()
        {
            var meetSlots = _context.MeetSlots
         .AsEnumerable()  // Veritabanı sorgusunu bitir, bellek tarafında çalışmaya başla
         .Where(m => DateTime.Parse(m.Date) < DateTime.Today)  // Tarih karşılaştırmasını bellek tarafında yap
         .ToList();

            // Eğer varsa bu randevuları sil
            if (meetSlots.Any())
            {
                _context.MeetSlots.RemoveRange(meetSlots);
                _context.SaveChanges();
            }
        }

        public MeetSlot? GetOneMeet(int id, bool trackChanges)
        {
            return FindByCondition(p => p.Id.Equals(id), trackChanges);
        }

        public void UpdateForMeet(MeetSlot entity) => Update(entity);

    }
}