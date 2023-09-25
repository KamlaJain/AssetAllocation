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
        [ForeignKey("AmenityLookUp")]
        public int AmenityId { get; set; }
        public virtual AmenityType AmenityType { get; set; }
        [ForeignKey("FacilityAsset")]
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        [ForeignKey("MeetingRoom")]
        public int? MeetingRoomId { get; set; }
        public virtual MeetingRoom? MeetingRoom { get; set; }
    }
}
