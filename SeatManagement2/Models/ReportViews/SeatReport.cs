using Microsoft.EntityFrameworkCore;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs.ReportDTOs;

namespace SeatManagement2.Models.ReportViews
{
    public class SeatReport : ISeatReport
    {
        private readonly IRepository<GeneralSeat> _seatrepository;
        public SeatReport(IRepository<GeneralSeat> seatrepository)
        {
            _seatrepository = seatrepository;
        }

        public IQueryable<SeatsViewDTO> GetSeatsReport()
        {
            var seats = _seatrepository.GetAll()
                .Include(s => s.Facility)
                .Include(s => s.Facility.CityLookUp)
                .Include(s => s.Facility.BuildingLookUp)
                .Include(s => s.Employee)
                .Select(s => new SeatsViewDTO
                {
                    CityCode = s.Facility.CityLookUp.CityCode,
                    BuildingCode = s.Facility.BuildingLookUp.BuildingCode,
                    FacilityName = s.Facility.FacilityName,
                    FloorNumber = s.Facility.FloorNumber,
                    EmployeeId = s.EmployeeId,
                    SeatNumber = s.SeatNumber,
                });
            return seats;
        }


    }
}
