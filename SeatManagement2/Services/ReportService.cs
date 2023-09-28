using SeatManagement2.DTOs.ReportDTOs;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Services
{
    public class ReportService : IReportService
    {
        private readonly ICabinReport _cabinsview;
        private readonly ISeatReport _seatsview;

        public ReportService(ICabinReport cabinsview, ISeatReport seatsview)
        {
            _seatsview = seatsview;
            _cabinsview = cabinsview;
        }


        public List<SeatsViewDTO> GenerateSeatsReport(bool isUnallocatedReport, string? cityCode, string? buildingCode, string? facilityName, int? floorNumber)
        {
            var report = _seatsview.GetSeatsReport();
            if (isUnallocatedReport)
            {
                report = report.Where(s => s.EmployeeId == null);
            }
            else
            {
                report = report.Where(s => s.EmployeeId != null);
            }

            if (cityCode != null)
            {
                report = report.Where(s => s.CityCode == cityCode);
            }
            if (buildingCode != null)
            {
                report = report.Where(s => s.BuildingCode == buildingCode);
            }
            if (facilityName != null)
            {
                report = report.Where(s => s.FacilityName == facilityName);
            }
            if (floorNumber.HasValue && floorNumber.Value != 0)
            {
                report = report.Where(s => s.FloorNumber == floorNumber);
            }

            return report.ToList();
        }

        public List<CabinsViewDTO> GenerateCabinsReport(bool isUnallocatedReport, string? cityCode, string? buildingCode, string? facilityName, int? floorNumber)
        {
            var report = _cabinsview.GetCabinsReport();
            if (isUnallocatedReport)
            {
                report = report.Where(s => s.EmployeeId == null);
            }
            else
            {
                report = report.Where(s => s.EmployeeId != null);
            }

            if (cityCode != null)
            {
                report = report.Where(s => s.CityCode == cityCode);
            }
            if (buildingCode != null)
            {
                report = report.Where(s => s.BuildingCode == buildingCode);
            }
            if (facilityName != null)
            {
                report = report.Where(s => s.FacilityName == facilityName);
            }
            if (floorNumber.HasValue && floorNumber.Value != 0)
            {
                report = report.Where(s => s.FloorNumber == floorNumber);
            }

            return report.ToList();
        }
    }
}

