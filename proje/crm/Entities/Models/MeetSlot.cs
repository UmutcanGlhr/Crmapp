namespace Entities.Models
{
    public class MeetSlot
    {
        public int Id { get; set; }
        public String? Date { get; set; }
        public String? Time { get; set; }
        public bool IsBooked { get; set; }

        public String? userID { get; set; }
        public AppUser? user { get; set; }
    }
}