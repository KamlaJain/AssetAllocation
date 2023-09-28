using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement2.Models
{
    public class MeetingRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeetingRoomId { get; set; }
        public int MeetingRoomNumber { get; set; }
        public int SeatingCapacity { get; set; }

        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }

    }
}
