using System.Collections.Generic;
using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IRoomAmenityService
    {
        List<RoomAmenity> GetAllRoomAmenities();
        void AddRoomAmenity(RoomAmenityDTO roomAmenityDTO);
        void DeleteRoomAmenity(int roomAmenityId);
        void UpdateAmenitiesInRoom(RoomAmenityDTO roomAmenityDTO);
    }
}

