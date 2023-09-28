using SeatManagement2.DTOs.ReportDTOs;
using SeatManagementFE.Implementation;
using SeatManagementFE.Interfaces;

namespace SeatManagementFE
{
    public class GetReports
    {
        ReportFilter filter = new ReportFilter();

        public void GetAllocatedSeatsReport()
        {
            string cityFilter, buildingFilter, facilityFilter;
            int floorFilter;
            NewMethod(out cityFilter, out buildingFilter, out facilityFilter, out floorFilter);
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

        private void NewMethod(out string cityFilter, out string buildingFilter, out string facilityFilter, out int floorFilter)
        {
            cityFilter = filter.CityFilter();
            buildingFilter = filter.BuildingFilter();
            facilityFilter = filter.FacilityNameFilter();
            floorFilter = filter.FloorFilter();
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
                Console.WriteLine("Allocated Cabins:\n");
                foreach (var c in report)
                {
                    Console.WriteLine($"{c.CityCode}- {c.BuildingCode}-{c.FloorNumber}-{c.FacilityName}- S{c.CabinNumber} - EmployeeId: {c.EmployeeId}");
                }
            }
            else
            {
                Console.WriteLine("No Allocated Cabins");
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
