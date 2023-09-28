using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement2.Models
{
    public class CabinRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CabinId { get; set; }
        public int CabinNumber { get; set; }
        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
