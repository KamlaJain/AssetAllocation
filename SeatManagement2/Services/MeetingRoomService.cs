using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class MeetingRoomService : IMeetingRoomService
    {
        private readonly IRepository<MeetingRoom> _repository;
        private readonly IRepository<Facility> _facilityrepository;

        public MeetingRoomService(IRepository<MeetingRoom> repository, IRepository<Facility> facilityrepository)
        {
            _repository = repository;
            _facilityrepository = facilityrepository;
        }

        public List<MeetingRoom> GetAllMeetingRooms()
        {
            return _repository.GetAll().ToList();
        }

        public void AddMeetingRoom(MeetingRoomDTO meetingRoomDTO)
        {
            if (!_facilityrepository.GetAll().Any(f => f.FacilityId == meetingRoomDTO.FacilityId))
            {
                throw new ResourceNotFoundException("The Facility does not exist.");
            }
            if (_repository.GetAll().Any(m => m.FacilityId == meetingRoomDTO.FacilityId && m.MeetingRoomNumber == meetingRoomDTO.MeetingRoomNumber))
            {
                throw new BadRequestException("Same meetingroom number exists in facility.");
            }

            var item = new MeetingRoom
            {
                MeetingRoomNumber = meetingRoomDTO.MeetingRoomNumber,
                SeatingCapacity = meetingRoomDTO.SeatingCapacity,
                FacilityId = meetingRoomDTO.FacilityId
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteMeetingRoom(int meetingRoomId)
        {
            var item = _repository.GetById(meetingRoomId);
            if (item == null)
            {
                throw new ResourceNotFoundException("Could not find meeting room");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }
    }
}
