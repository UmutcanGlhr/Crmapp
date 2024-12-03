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

        public void CancelSlot(int id)
        {
           var model= _manager.MeetSlot.GetOneMeet(id, false);
            var entity = new MeetSlot()
            {
                Id = model.Id,
                IsBooked = false,
                Date = model.Date,
                Time = model.Time,
                userID = model.userID
            };
            _manager.MeetSlot.UpdateForMeet(entity);
            _manager.Save();
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

        public void CreateMeetSlot(MeetSlot meetSlot)
        {
            _manager.MeetSlot.Create(meetSlot);
            _manager.Save();
        }

        public void DeletePastMeet()
        {
            _manager.MeetSlot.deleteMeet();
            _manager.Save();
        }

        public IEnumerable<Meet> GetAllMeet(bool trackChanges)
        {
            return _manager.Meet.GetAllMeet(trackChanges);
        }

        public IEnumerable<MeetSlot> GetAllMeetSlots(bool trackChanges)
        {
            return _manager.MeetSlot.FindAll(trackChanges);
        }

        public IEnumerable<Meet> getMeet(string? id)
        {
            return _manager.Meet.getMeet(id);
        }

        public MeetSlot? GetMeeting(int id, bool trackChanges)
        {
            var meet = _manager.MeetSlot.GetOneMeet(id, trackChanges);
            if (meet is null)
                throw new Exception(" Meet Not Found");
            return meet;
        }

        public IEnumerable<MeetSlot> GetMeetSlot(bool trackChanges, string id)
        {
            return _manager.MeetSlot.FindAll(false).Where(c => c.userID == id && c.IsBooked == false);
        }

        public IEnumerable<Meet> PastMeets(string? id)
        {
            return _manager.Meet.PastMeets(id);
        }

        public Meet? SorguKodu(string sorguKodu)
        {
            var model = _manager.Meet.FindAll(false).FirstOrDefault(c => c.sorguKodu == sorguKodu);
            return model;
        }

        public void UpdateMeetSlot(int id)
        {
            var model = _manager.MeetSlot.GetOneMeet(id, false);
            var entity = new MeetSlot()
            {
                Id = model.Id,
                IsBooked = true,
                Date = model.Date,
                Time = model.Time,
                userID = model.userID
            };
            _manager.MeetSlot.UpdateForMeet(entity);
            _manager.Save();
        }
    }
}