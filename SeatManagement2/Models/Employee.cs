using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement2.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        [DefaultValue("False")]
        public bool IsAllocated { get; set; }
        [ForeignKey("DepartmentLookUp")]
        public int DepartmentId { get; set; }
        public virtual DepartmentLookUp DepartmentLookUp { get; set; }

    }
}
