using Entities.Models;

namespace crm_app.Models
{
    public class RandevuViewModel
    {
        public IEnumerable<MeetSlot>? MeetSlots { get; set; }

        public AppUser? User { get; set; }
        public DateTime? SelectedDate { get; set; } 
    }
}