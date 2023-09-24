using System;
using System.Collections.Generic;
using System.Linq;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class MeetingRoomService : IMeetingRoomService
    {
        private readonly IRepository<MeetingRoom> _repository;

        public MeetingRoomService(IRepository<MeetingRoom> repository)
        {
            _repository = repository;
        }

        public List<MeetingRoom> GetAllMeetingRooms()
        {
            return _repository.GetAll().ToList();
        }

        public void AddMeetingRoom(MeetingRoomDTO meetingRoomDTO)
        {
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
