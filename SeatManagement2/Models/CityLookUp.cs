using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeatManagement2.Models
{
    [Index(nameof(CityCode), IsUnique = true)]
    public class CityLookUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public string? CityCode { get; set; }
    }
}

