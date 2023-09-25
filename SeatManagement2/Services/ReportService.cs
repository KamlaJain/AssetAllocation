using NuGet.Protocol.Core.Types;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

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

        public IEnumerable<UnallocatedSeatsView> GetUnallocatedSeatsReport()
        {
            return _unallocatedseatsview.GetAll().ToList();
        }

        public IEnumerable<AllocatedSeatsView> GetAllocatedSeatsReport()
        {
            return _allocatedseatsview.GetAll().ToList();
        }
        public IEnumerable<UnallocatedCabinsView> GetUnallocatedCabinsReport()
        {
            return _unallocatedcabinsview.GetAll().ToList();
        }

        public IEnumerable<AllocatedCabinsView> GetAllocatedCabinsReport()
        {
            return _allocatedcabinsview.GetAll().ToList();
        }

        public IEnumerable<BuildingLookUp> ApplyBuildingFilter(FilterDTO filterType)
        {
            var reqBuilding = _buildingrepository.GetAll().Where(b => b.BuildingId == filterType.BuildingId);
            if (reqBuilding == null)
            {
                throw new ResourceNotFoundException("No buildings found");
            }
            return reqBuilding.ToList();
        }

        public IEnumerable<Facility> ApplyFacilityFilter(FilterDTO filterType)
        {
            var reqFacility = _facilityrepository.GetAll().Where(f => f.FacilityId == filterType.FacilityId);
            if (reqFacility == null)
            {
                throw new ResourceNotFoundException("No facilities found");
            }
            return reqFacility.ToList();
        }
        public IEnumerable<Facility> ApplyFloorFilter(FilterDTO filterType)
        {
            var reqFloor = _facilityrepository.GetAll().Where(f => f.FloorNumber == filterType.FloorNumber);
            if (reqFloor == null)
            {
                throw new ResourceNotFoundException("No facilities in entered floor found");
            }
            return reqFloor.ToList();
        }

        public IEnumerable<Object> GenerateSeatsReport(bool isallocatedreport, int filterChoice, FilterDTO filterType)
        {

            if (isallocatedreport == true)
            {
                switch (filterChoice)
                {
                    case 1: //filterByBuilding
                        var reqBuilding = ApplyBuildingFilter(filterType);
                        var reqBuildingCode = reqBuilding.Select(b => b.BuildingCode);
                        var allocatedSeatsInBuilding = GetAllocatedSeatsReport().Where(a => reqBuildingCode.Contains(a.BuildingCode));
                        return allocatedSeatsInBuilding.ToList();

                    case 2: //filterbyFacility
                        var reqFacility = ApplyFacilityFilter(filterType);
                        var reqFacilityName = reqFacility.Select(f => f.FacilityName);
                        var allocatedSeatsInFacility = GetAllocatedSeatsReport().Where(a => reqFacilityName.Contains(a.FacilityName));
                        return allocatedSeatsInFacility.ToList();

                    case 3: //filterByFloor
                        var reqFloor = ApplyFloorFilter(filterType);
                        var reqFloorNumber = reqFloor.Select(f => f.FloorNumber);
                        var allocatedSeatsInFloor = GetAllocatedSeatsReport().Where(f => reqFloorNumber.Contains(f.FloorNumber));
                        return allocatedSeatsInFloor.ToList();

                    default:
                        return GetAllocatedSeatsReport();
                }
            }

            else
            {
                switch (filterChoice)
                {
                    case 1: //filterByBuilding
                        var reqBuilding = ApplyBuildingFilter(filterType);
                        var reqBuildingCode = reqBuilding.Select(b => b.BuildingCode);
                        var unallocatedSeatsInBuilding = GetUnallocatedSeatsReport().Where(a => reqBuildingCode.Contains(a.BuildingCode));
                        return unallocatedSeatsInBuilding.ToList();

                    case 2: //filterbyFacility
                        var reqFacility = ApplyFacilityFilter(filterType);
                        var reqFacilityName = reqFacility.Select(f => f.FacilityName);
                        var unallocatedSeatsInFacility = GetUnallocatedSeatsReport().Where(a => reqFacilityName.Contains(a.FacilityName));
                        return unallocatedSeatsInFacility.ToList();

                    case 3: //filterByFloor
                        var reqFloor = ApplyFloorFilter(filterType);
                        var reqFloorNumber = reqFloor.Select(f => f.FloorNumber);
                        var unallocatedSeatsInFloor = GetUnallocatedSeatsReport().Where(f => reqFloorNumber.Contains(f.FloorNumber));
                        return unallocatedSeatsInFloor.ToList();

                    default:
                        return GetUnallocatedSeatsReport();
                }
            }
        }
        public IEnumerable<object> GenerateCabinsReport(bool isallocatedreport, int filterChoice, FilterDTO filterType)
        {


            if (isallocatedreport == true)
            {
                switch (filterChoice)
                {
                    case 1: //filterByBuilding
                        var reqBuilding = ApplyBuildingFilter(filterType);
                        var reqBuildingCode = reqBuilding.Select(b => b.BuildingCode);
                        var allocatedCabinsInBuilding = GetAllocatedCabinsReport().Where(a => reqBuildingCode.Contains(a.BuildingCode));
                        return allocatedCabinsInBuilding.ToList();

                    case 2: //filterbyFacility
                        var reqFacility = ApplyFacilityFilter(filterType);
                        var reqFacilityName = reqFacility.Select(f => f.FacilityName);
                        var allocatedCabinsInFacility = GetAllocatedCabinsReport().Where(a => reqFacilityName.Contains(a.FacilityName));
                        return allocatedCabinsInFacility.ToList();

                    case 3: //filterByFloor
                        var reqFloor = ApplyFloorFilter(filterType);
                        var reqFloorNumber = reqFloor.Select(f => f.FloorNumber);
                        var allocatedCabinsInFloor = GetAllocatedCabinsReport().Where(f => reqFloorNumber.Contains(f.FloorNumber));
                        return allocatedCabinsInFloor.ToList();

                    default:
                        return GetAllocatedCabinsReport();
                }
            }
            else
            {
                switch (filterChoice)
                {
                    case 1: //filterByBuilding
                        var reqBuilding = ApplyBuildingFilter(filterType);
                        var reqBuildingCode = reqBuilding.Select(b => b.BuildingCode);
                        var unallocatedCabinsInBuilding = GetUnallocatedCabinsReport().Where(a => reqBuildingCode.Contains(a.BuildingCode));
                        return unallocatedCabinsInBuilding.ToList();

                    case 2: //filterbyFacility
                        var reqFacility = ApplyFacilityFilter(filterType);
                        var reqFacilityName = reqFacility.Select(f => f.FacilityName);
                        var unallocatedCabinsInFacility = GetUnallocatedCabinsReport().Where(a => reqFacilityName.Contains(a.FacilityName));
                        return unallocatedCabinsInFacility.ToList();

                    case 3: //filterByFloor
                        var reqFloor = ApplyFloorFilter(filterType);
                        var reqFloorNumber = reqFloor.Select(f => f.FloorNumber);
                        var unallocatedCabinsInFloor = GetUnallocatedCabinsReport().Where(f => reqFloorNumber.Contains(f.FloorNumber));
                        return unallocatedCabinsInFloor.ToList();

                    default:
                        return GetUnallocatedCabinsReport();
                }
            }
        }
    }
}
