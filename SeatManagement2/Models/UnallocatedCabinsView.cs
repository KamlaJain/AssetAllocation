using SeatManagement2.Interfaces;

namespace SeatManagement2.Models
{
    public class UnallocatedCabinsView : IReportView
    {
        public string CityCode { get; set; }

        public string BuildingCode { get; set; }

        public int FloorNumber { get; set; }

        public string FacilityName { get; set; }

        public int CabinNumber { get; set; }

        string IReportView.BuildingCode => this.BuildingCode;

        string IReportView.FacilityName => this.FacilityName;

        int? IReportView.FloorNumber => this.FloorNumber;
    }
}
