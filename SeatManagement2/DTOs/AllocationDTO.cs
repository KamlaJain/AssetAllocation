using SeatManagement2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SeatManagement2.DTOs
{
    public class AllocationDTO
    {
        public int SeatNumber { get; set; }

        public int FacilityId { get; set; }
        
        public int EmployeeId { get; set; }
    }
}
