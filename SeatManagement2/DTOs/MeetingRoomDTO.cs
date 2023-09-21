using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement2.DTOs
{
    public class MeetingRoomDTO
    {
        public int MeetingRoomNumber { get; set; }
        public int SeatingCapacity { get; set; }
        public int FacilityId { get; set; }
    }
}
