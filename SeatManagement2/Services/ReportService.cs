using NuGet.Protocol.Core.Types;
using SeatManagement2.DTOs;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class ReportService: IReportService
    {
        private readonly IRepository<UnallocatedSeats> _unallocatedseatsview;
        private readonly IRepository<AllocatedSeats> _allocatedseatsview;
        private readonly IRepository<BuildingLookUp> _buildingrepository;
        private readonly IRepository<Facility> _facilityrepository;

        public ReportService(IRepository<UnallocatedSeats> unallocatedseatsview, IRepository<AllocatedSeats> allocatedseatsview, IRepository<BuildingLookUp> buildingrepository, IRepository<Facility> facilityrepository)
        {
            _unallocatedseatsview = unallocatedseatsview;
            _allocatedseatsview = allocatedseatsview;
            _buildingrepository = buildingrepository;
            _facilityrepository = facilityrepository;
        }

        public IEnumerable<UnallocatedSeats> GetUnallocatedSeatsReport()
        {
            return _unallocatedseatsview.GetAll().ToList();
        }

        public IEnumerable<AllocatedSeats> GetAllocatedSeatsReport()
        {
            return _allocatedseatsview.GetAll().ToList();
        }

        public IEnumerable<BuildingLookUp> ApplyBuildingFilter(FilterDTO filterType)
        {
            var reqBuilding = _buildingrepository.GetAll().Where(b => b.BuildingId == filterType.BuildingId);
            if (reqBuilding == null)
            {
                throw new Exception("No buildings found");
            }
            return reqBuilding.ToList();
        }

        public IEnumerable<Facility> ApplyFacilityFilter(FilterDTO filterType)
        {
            var reqFacility = _facilityrepository.GetAll().Where(f => f.FacilityId == filterType.FacilityId);
            if (reqFacility == null)
            {
                throw new Exception("No facilities found");
            }
            return reqFacility.ToList();
        }
        public IEnumerable<Facility> ApplyFloorFilter(FilterDTO filterType)
        {
            var reqFloor = _facilityrepository.GetAll().Where(f => f.FloorNumber == filterType.FloorNumber);
            if (reqFloor == null)
            {
                throw new Exception("No facilities in entered floor found");
            }
            return reqFloor.ToList();
        }

        public IEnumerable<object> GenerateSeatsReport(bool isallocatedreport, int filterChoice, FilterDTO filterType)
        {
            if (isallocatedreport == true)
            {
                if (filterChoice == 1) //filterByBuilding
                {
                    var reqBuilding = ApplyBuildingFilter(filterType);
                    var reqBuildingCode = reqBuilding.Select(b => b.BuildingCode);
                    var allocatedSeatsInBuilding = GetAllocatedSeatsReport().Where(a => reqBuildingCode.Contains(a.BuildingCode));
                    return allocatedSeatsInBuilding.ToList();
                }

                if (filterChoice == 2) //filterbyFacility
                {
                    var reqFacility = ApplyFacilityFilter(filterType);
                    var reqFacilityName = reqFacility.Select(f => f.FacilityName);
                    var allocatedSeatsInFacility = GetAllocatedSeatsReport().Where(a => reqFacilityName.Contains(a.FacilityName));
                    return allocatedSeatsInFacility.ToList();
                }

                if (filterChoice == 3) //filterByFloor
                {
                    var reqFloor = ApplyFloorFilter(filterType);
                    var reqFloorNumber = reqFloor.Select(f => f.FloorNumber);
                    var allocatedSeatsInFloor = GetAllocatedSeatsReport().Where(f => reqFloorNumber.Contains(f.FloorNumber));
                    return allocatedSeatsInFloor.ToList();
                }

                return GetAllocatedSeatsReport();
            }

            else
            {
                if (filterChoice == 1) //filterByBuilding
                {
                    var reqBuilding = ApplyBuildingFilter(filterType);
                    var reqBuildingCode = reqBuilding.Select(b => b.BuildingCode);
                    var unallocatedSeatsInBuilding = GetUnallocatedSeatsReport().Where(a => reqBuildingCode.Contains(a.BuildingCode));
                    return unallocatedSeatsInBuilding.ToList();
                }

                if (filterChoice == 2) //filterbyFacility
                {
                    var reqFacility = ApplyFacilityFilter(filterType);
                    var reqFacilityName = reqFacility.Select(f => f.FacilityName);
                    var unallocatedSeatsInFacility = GetUnallocatedSeatsReport().Where(a => reqFacilityName.Contains(a.FacilityName));
                    return unallocatedSeatsInFacility.ToList();
                }

                if (filterChoice == 3) //filterByFloor
                {
                    var reqFloor = ApplyFloorFilter(filterType);
                    var reqFloorNumber = reqFloor.Select(f => f.FloorNumber);
                    var unallocatedSeatsInFloor = GetUnallocatedSeatsReport().Where(f => reqFloorNumber.Contains(f.FloorNumber));
                    return unallocatedSeatsInFloor.ToList();
                }
                return GetUnallocatedSeatsReport();
            }
        }
    }
}
