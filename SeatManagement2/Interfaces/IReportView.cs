namespace SeatManagement2.Interfaces
{
    public interface IReportView
    {
        string BuildingCode { get; }
        string FacilityName { get; }
        int? FloorNumber { get; }
    }
}
