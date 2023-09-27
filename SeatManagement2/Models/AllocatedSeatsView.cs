using System;
using System.ComponentModel.DataAnnotations;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Models
{
    public class AllocatedSeatsView : IReportView
    {
        public string CityCode { get; set; }
        public string BuildingCode { get; set; }
        public int FloorNumber { get; set; }
        public string FacilityName { get; set; }
        public int SeatNumber { get; set; }
        public int? EmployeeId { get; set; }

        string IReportView.CityCode => this.CityCode;
        string IReportView.BuildingCode => this.BuildingCode;
        string IReportView.FacilityName => this.FacilityName;
        int? IReportView.FloorNumber => this.FloorNumber;
    }
}
