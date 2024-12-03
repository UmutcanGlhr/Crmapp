using Entities.Models;

namespace crm_app.Models
{
    public class MeetPageModel
    {
        public Meet? meet { get; set; }

        public MeetSlot? meetSlot { get; set; }
    }
}