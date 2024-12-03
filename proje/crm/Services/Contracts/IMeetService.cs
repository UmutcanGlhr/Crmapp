using Entities.Models;

namespace Services.Contracts
{
    public interface IMeetService
    {
        IEnumerable<Meet> GetAllMeet(bool trackChanges);

        IEnumerable<MeetSlot> GetMeetSlot(bool trackChanges, string id);

        IEnumerable<MeetSlot> GetAllMeetSlots(bool trackChanges);
        MeetSlot? GetMeeting(int id, bool trackChanges);

        void UpdateMeetSlot(int id);

        void CancelSlot(int id);

        void CreateMeet(Meet meet);
        void CreateMeetSlot(MeetSlot meetSlot);

        IEnumerable<Meet> getMeet(string? id);
        IEnumerable<Meet> PastMeets(string? id);

        void Complete(int id);

        void DeletePastMeet();

        public Meet? SorguKodu(string sorguKodu);
    }
}