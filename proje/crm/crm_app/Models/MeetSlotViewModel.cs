using Entities.Models;

namespace crm_app.Models
{
    public class MeetSlotViewModel
    {
        public IEnumerable<MeetSlot>? meetSlots { get; set; }

        public MeetSlot? meet { get; set; }
    }
}