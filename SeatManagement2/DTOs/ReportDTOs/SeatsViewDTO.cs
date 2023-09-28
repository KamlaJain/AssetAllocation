namespace SeatManagement2.DTOs.ReportDTOs
{
    public class SeatsViewDTO
    {
        public string CityCode { get; set; }
        public string BuildingCode { get; set; }
        public int FloorNumber { get; set; }
        public string FacilityName { get; set; }
        public int SeatNumber { get; set; }
        public int? EmployeeId { get; set; }


    }
}
