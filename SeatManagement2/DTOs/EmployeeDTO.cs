using SeatManagement2.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SeatManagement2.DTOs
{
    public class EmployeeDTO
    {
        public string? EmployeeName { get; set; }
        public int DepartmentId { get; set; }
    }
}
