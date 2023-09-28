using SeatManagement2.DTOs.ReportDTOs;
using SeatManagement2.Models;
using SeatManagementFE.Implementation;
using SeatManagementFE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementFE
{
    public class GetReports
    {
        ReportFilter filter = new ReportFilter();

        public void GetAllocatedSeatsReport()
        {
            var cityFilter = filter.CityFilter();
            var buildingFilter = filter.BuildingFilter();
            var facilityFilter = filter.FacilityNameFilter();
            var floorFilter = filter.FloorFilter();
            IEntityManager<SeatsViewDTO> alseat = new EntityManager<SeatsViewDTO>($"GeneralSeat/Reports?isUnallocatedReport=false&cityCode={cityFilter}&buildingCode={buildingFilter}&facilityName={facilityFilter}&floorNumber={floorFilter}");
            var report = alseat.Get();
            if (report.ToList().Count != 0)
            {
                Console.WriteLine("Allocated Seats:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.SeatNumber} - EmployeeId: {c.EmployeeId}");
                }
            }
            else
            {
                Console.WriteLine("No Allocated Seats");
            }
        }
        public void GetFreeSeatsReport()
        {
            var cityFilter = filter.CityFilter();
            var buildingFilter = filter.BuildingFilter();
            var facilityFilter = filter.FacilityNameFilter();
            var floorFilter = filter.FloorFilter();
            IEntityManager<SeatsViewDTO> unalseat = new EntityManager<SeatsViewDTO>($"GeneralSeat/Reports?isUnallocatedReport=true&cityCode={cityFilter}&buildingCode={buildingFilter}&facilityName={facilityFilter}&floorNumber={floorFilter}");
            var report = unalseat.Get();
            if (report.ToList().Count != 0)
            {

                Console.WriteLine("Unallocated Seats:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.SeatNumber}");
                }
            }
            else
            {
                Console.WriteLine("No Unallocated Seats");
            }
        }

        public void GetAllocatedCabinsReport()
        {
            var cityFilter = filter.CityFilter();
            var buildingFilter = filter.BuildingFilter();
            var facilityFilter = filter.FacilityNameFilter();
            var floorFilter = filter.FloorFilter();
            IEntityManager<CabinsViewDTO> alcabin = new EntityManager<CabinsViewDTO>($"CabinRoom/Reports?isUnallocatedReport=false&cityCode={cityFilter}&buildingCode={buildingFilter}&facilityName={facilityFilter}&floorNumber={floorFilter}");
            var report = alcabin.Get();
            if (report.ToList().Count != 0)
            {

                Console.WriteLine("Unallocated Cabins:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.CabinNumber} - EmployeeId: {c.EmployeeId}");
                }
            }
            else
            {
                Console.WriteLine("No Unallocated Cabins");
            }
        }
        public void GetFreeCabinsReport()
        {
            var cityFilter = filter.CityFilter();
            var buildingFilter = filter.BuildingFilter();
            var facilityFilter = filter.FacilityNameFilter();
            var floorFilter = filter.FloorFilter();
            IEntityManager<CabinsViewDTO> unalcabin = new EntityManager<CabinsViewDTO>($"CabinRoom/Reports?isUnallocatedReport=true&cityCode={cityFilter}&buildingCode={buildingFilter}&facilityName={facilityFilter}&floorNumber={floorFilter}");
            var report = unalcabin.Get();
            if (report.ToList().Count != 0)
            {

                Console.WriteLine("Unallocated Cabins:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.CabinNumber}");
                }
            }
            else
            {
                Console.WriteLine("No Unallocated Cabins");
            }


        }
    }
}
