using System.Collections.Generic;
using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IAmenityService
    {
        List<RoomAmenity> GetAllAmenities();
        void AddAmenityToFacility(RoomAmenityDTO roomAmenityDTO);
        void DeleteAmenity(int roomAmenityId);
        void UpdateAmenitiesInRoom(RoomAmenityDTO roomAmenityDTO);
    }
}

