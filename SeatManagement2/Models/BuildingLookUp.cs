using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement2.Models
{
    [Index(nameof(BuildingCode), IsUnique = true)]

    public class BuildingLookUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildingId { get; set; }
        public string? BuildingName { get; set; }
        public string? BuildingCode { get; set; }
    }
}
