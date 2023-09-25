using System;
using System.Collections.Generic;
using System.Linq;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class AmenityService : IAmenityService
    {
        private readonly IRepository<RoomAmenity> _repository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<AmenityType> _amenityRepository;
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;


        public AmenityService(IRepository<RoomAmenity> repository, IRepository<Facility> facilityRepository, IRepository<AmenityType> amenityRepository, IRepository<MeetingRoom> meetingRoomRepository)
        {
            _repository = repository;
            _facilityRepository = facilityRepository;
            _amenityRepository = amenityRepository;
            _meetingRoomRepository = meetingRoomRepository;
        }

        public List<RoomAmenity> GetAllAmenities()
        {
            return _repository.GetAll().ToList();
        }

        public void AddAmenityToFacility(RoomAmenityDTO roomAmenityDTO)
        {
            var amenity = _amenityRepository.GetById(roomAmenityDTO.AmenityId);
            if (amenity == null)
            {
                throw new ResourceNotFoundException("Amenity not found.");
            }

            var facility = _facilityRepository.GetById(roomAmenityDTO.FacilityId);
            if (facility == null)
            {
                throw new ResourceNotFoundException("Facility not found.");
            }

            var item = new RoomAmenity
            {
                AmenityId = roomAmenityDTO.AmenityId,
                FacilityId = roomAmenityDTO.FacilityId,
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteAmenity(int roomAmenityId)
        {
            var item = _repository.GetById(roomAmenityId);
            if (item == null)
            {
                throw new ResourceNotFoundException("Could not find room amenity");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }

        public void UpdateAmenitiesInRoom(RoomAmenityDTO roomAmenity)
        {
            var reqRoomAmenity = _repository.GetAll().FirstOrDefault(ra => ra.FacilityId == roomAmenity.FacilityId && ra.AmenityId == roomAmenity.AmenityId);
            if (reqRoomAmenity == null)
            {
                throw new ResourceNotFoundException("No such Amenity in Facility");
            }

            var meetingRoom = _meetingRoomRepository.GetAll().Where(ra => ra.MeetingRoomId == roomAmenity.MeetingRoomId && ra.FacilityId == reqRoomAmenity.FacilityId);
            if (meetingRoom == null)
            {
                throw new ResourceNotFoundException("Meeting Room does not exist in Facility");
            }

            if (reqRoomAmenity.MeetingRoomId.HasValue)
            {
                //RemoveAmenityFromMeetingroom(reqRoomAmenity);
                reqRoomAmenity.MeetingRoomId = null;
                _repository.Update(reqRoomAmenity);
                _repository.Save();
            }
            else
            {
                //AddAmenityToMeetingroom(reqRoomAmenity, roomAmenity);
                reqRoomAmenity.MeetingRoomId = roomAmenity.MeetingRoomId;
                _repository.Update(reqRoomAmenity);
                _repository.Save();
            }
        }
    }
}


