﻿using System;
using System.Collections.Generic;
using System.Linq;
using SeatManagement2.DTOs;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class RoomAmenityService : IRoomAmenityService
    {
        private readonly IRepository<RoomAmenity> _repository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<AmenityLookUp> _amenityRepository;
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;


        public RoomAmenityService(IRepository<RoomAmenity> repository, IRepository<Facility> facilityRepository, IRepository<AmenityLookUp> amenityRepository, IRepository<MeetingRoom> meetingRoomRepository)
        {
            _repository = repository;
            _facilityRepository = facilityRepository;
            _amenityRepository = amenityRepository;
            _meetingRoomRepository = meetingRoomRepository;
        }

        public List<RoomAmenity> GetAllRoomAmenities()
        {
            return _repository.GetAll().ToList();
        }

        public void AddRoomAmenity(RoomAmenityDTO roomAmenityDTO)
        {
            var amenity = _amenityRepository.GetById(roomAmenityDTO.AmenityId);
            if (amenity == null)
            {
                throw new Exception("Amenity not found.");
            }

            var facility = _facilityRepository.GetById(roomAmenityDTO.FacilityId);
            if (facility == null)
            {
                throw new Exception("Facility not found.");
            }

            var item = new RoomAmenity
            {
                AmenityId = roomAmenityDTO.AmenityId,
                FacilityId = roomAmenityDTO.FacilityId,
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteRoomAmenity(int roomAmenityId)
        {
            var item = _repository.GetById(roomAmenityId);
            if (item == null)
            {
                throw new Exception("Could not find room amenity");
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
                throw new Exception("No such Amenity in Facility");
            }

            var meetingRoom = _meetingRoomRepository.GetAll().Where(ra => ra.MeetingRoomId == roomAmenity.MeetingRoomId && ra.FacilityId == reqRoomAmenity.FacilityId);
            if (meetingRoom == null)
            {
                throw new Exception("Meeting Room does not exist in Facility");
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


