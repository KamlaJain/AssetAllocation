using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement2.Models
{
    public class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacilityId { get; set; }
        public string? FacilityName { get; set; }
        public int FloorNumber { get; set; }
        [ForeignKey("BuildingLookUp")]
        public int BuildingId { get; set; }
        public virtual BuildingLookUp BuildingLookUp { get; set; }
        [ForeignKey("CityLookUp")]
        public int CityId { get; set; }
        public virtual CityLookUp CityLookUp { get; set; }
    }
}
