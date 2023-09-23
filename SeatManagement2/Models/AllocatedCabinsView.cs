namespace SeatManagement2.Models
{
    public class AllocatedCabinsView
    {
        public string CityCode { get; set; }

        public string BuildingCode { get; set; }

        public int FloorNumber { get; set; }

        public string FacilityName { get; set; }

        public int CabinNumber { get; set; }

        public int? EmployeeId { get; set; }
    }
}
