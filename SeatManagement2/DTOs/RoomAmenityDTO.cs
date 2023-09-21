using SeatManagement2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SeatManagement2.DTOs
{
    public class RoomAmenityDTO
    {
        public int AmenityId { get; set; }
        public int FacilityId { get; set; }
        public int MeetingRoomId { get; set; }
    }
}

