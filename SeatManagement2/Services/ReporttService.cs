/*using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeatManagement2.Services
{
    public class ReportService : IReportService
    {
        private readonly IRepository<UnallocatedSeatsView> _unallocatedSeatsViewRepo;
        private readonly IRepository<AllocatedSeatsView> _allocatedSeatsViewRepo;
        private readonly IRepository<BuildingLookUp> _buildingRepo;
        private readonly IRepository<Facility> _facilityRepo;
        private readonly IRepository<UnallocatedCabinsView> _unallocatedCabinsViewRepo;
        private readonly IRepository<AllocatedCabinsView> _allocatedCabinsViewRepo;

        public ReportService(
            IRepository<UnallocatedSeatsView> unallocatedSeatsViewRepo,
            IRepository<AllocatedSeatsView> allocatedSeatsViewRepo,
            IRepository<BuildingLookUp> buildingRepo,
            IRepository<Facility> facilityRepo,
            IRepository<UnallocatedCabinsView> unallocatedCabinsViewRepo,
            IRepository<AllocatedCabinsView> allocatedCabinsViewRepo)
        {
            _unallocatedSeatsViewRepo = unallocatedSeatsViewRepo;
            _allocatedSeatsViewRepo = allocatedSeatsViewRepo;
            _buildingRepo = buildingRepo;
            _facilityRepo = facilityRepo;
            _unallocatedCabinsViewRepo = unallocatedCabinsViewRepo;
            _allocatedCabinsViewRepo = allocatedCabinsViewRepo;
        }

        public IEnumerable<UnallocatedSeatsView> GetUnallocatedSeatsReport() => _unallocatedSeatsViewRepo.GetAll().ToList();

        public IEnumerable<AllocatedSeatsView> GetAllocatedSeatsReport() => _allocatedSeatsViewRepo.GetAll().ToList();

        public IEnumerable<UnallocatedCabinsView> GetUnallocatedCabinsReport() => _unallocatedCabinsViewRepo.GetAll().ToList();

        public IEnumerable<AllocatedCabinsView> GetAllocatedCabinsReport() => _allocatedCabinsViewRepo.GetAll().ToList();

        public IEnumerable<BuildingLookUp> ApplyBuildingFilter(FilterDTO filterType)
        {
            var reqBuilding = _buildingRepo.GetAll().Where(b => b.BuildingId == filterType.BuildingId).ToList();
            if (!reqBuilding.Any())
            {
                throw new ResourceNotFoundException("No buildings found");
            }
            return reqBuilding;
        }

        public IEnumerable<Facility> ApplyFacilityFilter(FilterDTO filterType)
        {
            var reqFacility = _facilityRepo.GetAll().Where(f => f.FacilityId == filterType.FacilityId).ToList();
            if (!reqFacility.Any())
            {
                throw new ResourceNotFoundException("No facilities found");
            }
            return reqFacility;
        }

        public IEnumerable<Facility> ApplyFloorFilter(FilterDTO filterType)
        {
            var reqFloor = _facilityRepo.GetAll().Where(f => f.FloorNumber == filterType.FloorNumber).ToList();
            if (!reqFloor.Any())
            {
                throw new ResourceNotFoundException("No facilities in entered floor found");
            }
            return reqFloor;
        }

        public IEnumerable<object> GenerateSeatsReport(bool isAllocatedReport, int filterChoice, FilterDTO filterType)
        {
            var filterCriteria = GetFilterCriteria<AllocatedSeatsView>(isAllocatedReport, filterChoice, filterType);
            var seatsReport = isAllocatedReport ? GetAllocatedSeatsReport() : GetUnallocatedSeatsReport();
            return FilterReportByCriteria(seatsReport, filterCriteria);
        }

        public IEnumerable<object> GenerateCabinsReport(bool isAllocatedReport, int filterChoice, FilterDTO filterType)
        {
            var filterCriteria = GetFilterCriteria<AllocatedCabinsView>(isAllocatedReport, filterChoice, filterType);
            var cabinsReport = isAllocatedReport ? GetAllocatedCabinsReport() : GetUnallocatedCabinsReport();
            return FilterReportByCriteria(cabinsReport, filterCriteria);
        }

        private Func<T, bool> GetFilterCriteria<T>(bool isAllocatedReport, int filterChoice, FilterDTO filterType)
        {
            IEnumerable<BuildingLookUp> reqBuilding = null;
            IEnumerable<Facility> reqFacility = null;

            if (filterChoice == 1)
            {
                reqBuilding = ApplyBuildingFilter(filterType);
            }
            else if (filterChoice == 2)
            {
                reqFacility = ApplyFacilityFilter(filterType);
            }

            return item =>
            {
                if (isAllocatedReport)
                {
                    if (filterChoice == 1 && reqBuilding != null)
                    {
                        var reqBuildingCode = reqBuilding.Select(b => b.BuildingCode);
                        return reqBuildingCode.Contains(GetBuildingCode(item));
                    }
                    else if (filterChoice == 2 && reqFacility != null)
                    {
                        var reqFacilityName = reqFacility.Select(f => f.FacilityName);
                        return reqFacilityName.Contains(GetFacilityName(item));
                    }
                    else if (filterChoice == 3)
                    {
                        var reqFloor = ApplyFloorFilter(filterType);
                        var reqFloorNumber = reqFloor.Select(f => f.FloorNumber);
                        return reqFloorNumber.Contains(GetFloorNumber(item));
                    }
                }
                return true; // No filtering
            };
        }

        private IEnumerable<object> FilterReportByCriteria(IEnumerable<object> report, Func<object, bool> filterCriteria) =>
            report.Where(filterCriteria).ToList();

        private string GetBuildingCode(object item)
        {
            if (item is AllocatedSeatsView allocatedSeatsView)
                return allocatedSeatsView.BuildingCode;

            if (item is AllocatedCabinsView allocatedCabinsView)
                return allocatedCabinsView.BuildingCode;

            return string.Empty;
        }

        private string GetFacilityName(object item)
        {
            if (item is AllocatedSeatsView allocatedSeatsView)
                return allocatedSeatsView.FacilityName;

            if (item is AllocatedCabinsView allocatedCabinsView)
                return allocatedCabinsView.FacilityName;

            return string.Empty;
        }

        private int GetFloorNumber(object item)
        {
            if (item is AllocatedSeatsView allocatedSeatsView)
                return allocatedSeatsView.FloorNumber;

            if (item is AllocatedCabinsView allocatedCabinsView)
                return allocatedCabinsView.FloorNumber;

            return 0;
        }
    }
}
*/