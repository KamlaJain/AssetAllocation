using Microsoft.EntityFrameworkCore;
using SeatManagement2.DTOs.ReportDTOs;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Models.ReportViews
{
    public class CabinReport : ICabinReport
    {
        private readonly IRepository<CabinRoom> _cabinrepository;
        public CabinReport(IRepository<CabinRoom> cabinrepository)
        {
            _cabinrepository = cabinrepository;
        }

        public IQueryable<CabinsViewDTO> GetCabinsReport()
        {
            var seats = _cabinrepository.GetAll()
                .Include(s => s.Facility)
                .Include(s => s.Facility.CityLookUp)
                .Include(s => s.Facility.BuildingLookUp)
                .Include(s => s.Employee)
                .Select(s => new CabinsViewDTO
                {
                    CityCode = s.Facility.CityLookUp.CityCode,
                    BuildingCode = s.Facility.BuildingLookUp.BuildingCode,
                    FacilityName = s.Facility.FacilityName,
                    FloorNumber = s.Facility.FloorNumber,
                    EmployeeId = s.EmployeeId,
                    CabinNumber = s.CabinNumber,
                });
            return seats;
        }
    }
}
