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
        public void AllocateRoomAmenity(RoomAmenityDTO roomAmenityDTO)
        {
            var existingAllocation = _repository.GetAll()
                .FirstOrDefault(ra => ra.AmenityId == roomAmenityDTO.AmenityId && ra.FacilityId == roomAmenityDTO.FacilityId);

            if (existingAllocation == null)
            {
                throw new Exception("Amenity not found");
            }

            var meetingRoom = _meetingRoomRepository.GetAll().Where(ra => ra.MeetingRoomId == roomAmenityDTO.MeetingRoomId && ra.FacilityId == existingAllocation.FacilityId);
            if (meetingRoom == null)
            {
                throw new Exception("Meeting Room not found.");
            }

            existingAllocation.MeetingRoomId = roomAmenityDTO.MeetingRoomId;

            _repository.Update(existingAllocation);
            _repository.Save();


        }
        public void DeallocateRoomAmenity(RoomAmenityDTO roomAmenityDTO)
        {
            var amenity = _amenityRepository.GetById(roomAmenityDTO.AmenityId);
            if (amenity == null)
            {
                throw new Exception("Amenity not found.");
            }

            var existingAllocation = _repository.GetAll().FirstOrDefault(ra => ra.AmenityId == amenity.AmenityId && ra.FacilityId == roomAmenityDTO.FacilityId);

            if (existingAllocation == null)
            {
                throw new Exception("Amenity is not allocated to the Meeting Room.");
            }

            existingAllocation.MeetingRoomId = null;

            _repository.Update(existingAllocation);
            _repository.Save();

        }

    }
}
