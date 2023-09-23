using SeatManagement2.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SeatManagement2.Interfaces;

namespace SeatManagement2
{
    public class SeatManagementContext: DbContext
    {
        public SeatManagementContext(DbContextOptions options) : base(options) { }

        public DbSet<CityLookUp> CityLookUps { get; set; }
        public DbSet<BuildingLookUp> BuildingLookUps { get; set; }
        public DbSet<AmenityLookUp> AmenityLookUp { get; set; }
        public DbSet<DepartmentLookUp> DepartmentLookUps { get; set; }
        public DbSet<Facility> Facilitys { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<GeneralSeat> GeneralSeats{ get; set; }
        public DbSet<CabinRoom> CabinRooms { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<AllocatedSeats>()
                .ToView("AllocatedSeats")
                .HasKey(e => new { e.FacilityName, e.SeatNumber, e.EmployeeId });
            modelBuilder
                .Entity<UnallocatedSeats>()
                .ToView("UnallocatedSeats")
                .HasKey(e => new { e.FacilityName, e.SeatNumber });
            modelBuilder
                .Entity<AllocatedCabinsView>()
                .ToView("AllocatedCabinsView")
                .HasKey(e => new { e.FacilityName, e.CabinNumber, e.EmployeeId });
            modelBuilder
                .Entity<UnallocatedCabinsView>()
                .ToView("UnallocatedCabinsView")
                .HasKey (e => new { e.FacilityName,e.CabinNumber});
        }

    }
}
