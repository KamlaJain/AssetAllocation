using NuGet.Protocol.Core.Types;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;
using System.Composition;

namespace SeatManagement2.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<UnallocatedSeatsView> _unallocatedseatsview;
        private readonly IRepository<AllocatedSeatsView> _allocatedseatsview;
        private readonly IRepository<BuildingLookUp> _buildingrepository;
        private readonly IRepository<Facility> _facilityrepository;
        private readonly IRepository<UnallocatedCabinsView> _unallocatedcabinsview;
        private readonly IRepository<AllocatedCabinsView> _allocatedcabinsview;


        public ReportService(IRepository<UnallocatedSeatsView> unallocatedseatsview, IRepository<AllocatedSeatsView> allocatedseatsview, IRepository<BuildingLookUp> buildingrepository, IRepository<Facility> facilityrepository, IRepository<AllocatedCabinsView> allocatedcabinsview, IRepository<UnallocatedCabinsView> unallocatedcabinsview)
        {
            _unallocatedseatsview = unallocatedseatsview;
            _allocatedseatsview = allocatedseatsview;
            _buildingrepository = buildingrepository;
            _facilityrepository = facilityrepository;
            _allocatedcabinsview = allocatedcabinsview;
            _unallocatedcabinsview = unallocatedcabinsview;
        }

        public IEnumerable<IReportView> GetUnallocatedSeatsReport()
        {
            var unallocatedSeats = _unallocatedseatsview.GetAll().ToList();
            return unallocatedSeats.Cast<IReportView>();
        }

        public IEnumerable<IReportView> GetAllocatedSeatsReport()
        {
            var allocatedSeats = _allocatedseatsview.GetAll().ToList();
            return allocatedSeats.Cast<IReportView>();
        }
        public IEnumerable<IReportView> GetUnallocatedCabinsReport()
        {
            var unallocatedCabins = _unallocatedcabinsview.GetAll().ToList();
            return unallocatedCabins.Cast<IReportView>();
        }

        public IEnumerable<IReportView> GetAllocatedCabinsReport()
        {
            var allocatedCabins = _allocatedcabinsview.GetAll().ToList();
            return allocatedCabins.Cast<IReportView>();
        }

        public IEnumerable<IReportView> GenerateSeatsReport(bool isUnallocatedReport, string? buildingCode, string? facilityName, int? floorNumber)
        {
            var report = isUnallocatedReport ? GetUnallocatedSeatsReport(): GetAllocatedSeatsReport();
            report = ApplyFilters(report, buildingCode, facilityName, floorNumber);
            return report.ToList();
        }

        public IEnumerable<IReportView> GenerateCabinsReport(bool isUnallocatedReport, string? buildingCode, string? facilityName, int? floorNumber)
        {
            var report = isUnallocatedReport ? GetUnallocatedCabinsReport() : GetAllocatedCabinsReport();
            report = ApplyFilters(report, buildingCode, facilityName, floorNumber);
            return report.ToList();
        }

        private IEnumerable<IReportView> ApplyFilters(IEnumerable<IReportView> report, string? buildingCode, string? facilityName, int? floorNumber)
        {
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

