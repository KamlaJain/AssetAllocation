using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SeatManagement2.Models
{
    public class RoomAmenity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomAmenityId { get; set; }
        public int? AmenityId { get; set; }
        public int FacilityId { get; set; }
        public int? MeetingRoomId { get; set; }

        [ForeignKey("AmenityId")]
        public virtual AmenityType? AmenityType { get; set; }
        [ForeignKey("FacilityId")]
        public virtual Facility Facility { get; set; }
        [ForeignKey("MeetingRoomId")]
        public virtual MeetingRoom? MeetingRoom { get; set; }



    }
}
