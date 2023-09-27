namespace SeatManagement2.Interfaces
{
    public interface IReportView
    {
        string CityCode { get; }
        string BuildingCode { get; }
        string FacilityName { get; }
        int? FloorNumber { get; }
    }
}
