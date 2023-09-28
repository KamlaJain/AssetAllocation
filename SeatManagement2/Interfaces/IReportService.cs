using SeatManagement2.DTOs.ReportDTOs;

namespace SeatManagement2.Interfaces
{
    public interface IReportService
    {
        List<SeatsViewDTO> GenerateSeatsReport(bool isUnallocatedReport, string? cityCode, string? buildingCode, string? facilityName, int? floorNumber);
        List<CabinsViewDTO> GenerateCabinsReport(bool isUnallocatedReport, string? cityCode, string? buildingCode, string? facilityName, int? floorNumber);
    }
}
