using System.Collections.Generic;
using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface ICabinRoomService
    {
        List<CabinRoom> GetAllCabinRooms();
        void AddCabinRoom(CabinRoomDTO cabinRoomDTO);
        void DeleteCabinRoom(int cabinId);
        void UpdateEmployeeCabinAllocationStatus(CabinRoomDTO seat);
    }
}
