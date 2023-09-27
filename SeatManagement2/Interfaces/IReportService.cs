using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IReportService
    {
        IEnumerable<IReportView> GenerateSeatsReport(bool isUnallocatedReport, string? cityCode, string? buildingCode, string? facilityName, int? floorNumber);
        IEnumerable<IReportView> GenerateCabinsReport(bool isUnallocatedReport, string? cityCode, string? buildingCode, string? facilityName, int? floorNumber);
    }
}
