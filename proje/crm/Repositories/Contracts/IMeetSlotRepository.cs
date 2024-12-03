using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Repositories.Contracts
{
    public interface IMeetSlotRepository : IRepositoryBase<MeetSlot>
    {
        MeetSlot? GetOneMeet(int id, bool trackChanges);
        void UpdateForMeet(MeetSlot entity);

        void deleteMeet();
    }
}