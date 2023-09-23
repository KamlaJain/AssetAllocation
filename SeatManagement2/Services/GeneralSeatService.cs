using System;
using System.Collections.Generic;
using System.Linq;
using SeatManagement2.DTOs;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class GeneralSeatService : IGeneralSeatService
    {
        private readonly IRepository<GeneralSeat> _repository;
        private readonly IRepository<Facility> _frepository;
        private readonly IRepository<Employee> _employeerepo;
        private readonly IRepository<UnallocatedSeats> _unallocatedseatsview;
        private readonly IRepository<AllocatedSeats> _allocatedseatsview;
        private readonly IRepository<BuildingLookUp> _buildingrepository;

        public GeneralSeatService(IRepository<GeneralSeat> repository, IRepository<Facility> facilityrepository, IRepository<Employee> employeerepo, IRepository<UnallocatedSeats> unallocatedseatsrepo, IRepository<AllocatedSeats> allocatedseatsrepo, IRepository<BuildingLookUp> buildingrepository)
        {
            _repository = repository;
            _frepository = facilityrepository;
            _employeerepo = employeerepo;
            _unallocatedseatsview = unallocatedseatsrepo;
            _allocatedseatsview = allocatedseatsrepo;
            _buildingrepository = buildingrepository;
        }

        public List<GeneralSeat> GetAllGeneralSeats()
        {
            return _repository.GetAll().ToList();
        }

        public void AddGeneralSeat(GeneralSeatDTO generalSeatDTO)
        {
            if (_repository.GetAll().Any(s => s.SeatNumber == generalSeatDTO.SeatNumber && s.FacilityId == generalSeatDTO.FacilityId))
            {
                throw new Exception("Seat with the same SeatNumber and FacilityId already exists.");
            }
            var item = new GeneralSeat
            {
                SeatNumber = generalSeatDTO.SeatNumber,
                FacilityId = generalSeatDTO.FacilityId,
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteGeneralSeat(int seatId)
        {
            var item = _repository.GetById(seatId);
            if (item == null)
            {
                throw new Exception("Could not find general seat");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }



        public void UpdateEmployeeSeatAllocationStatus(GeneralSeatDTO seat)
        {
            // check if such a row with given facilityId and seatnumber exists in db
            var reqseat = _repository.GetAll().FirstOrDefault(s => s.SeatNumber == seat.SeatNumber && s.FacilityId == seat.FacilityId);
            if (reqseat == null)
            {
                throw new Exception("Seat not found.");
            }

            //to deallocate employee if given value contains an employeeId
            if (reqseat.EmployeeId.HasValue)
            {
                DeallocateEmployee(reqseat);
            }
            else
            {
                AllocateEmployee(reqseat, seat);
            }
        }
        public void DeallocateEmployee(GeneralSeat reqseat)
        {

            var emp = _employeerepo.GetAll().FirstOrDefault(e => e.EmployeeId == reqseat.EmployeeId);
            if (emp == null)
            {
                throw new Exception("Employee not found.");
            }

            int empId = reqseat.EmployeeId.Value;
            var employee = _employeerepo.GetById(empId); //find and make isAllocated false in employeetable for employeeId given
            employee.IsAllocated = false;
            _employeerepo.Update(employee);

            reqseat.EmployeeId = null; //set empId of seatsrepo to null
            _repository.Update(reqseat);
            _repository.Save();

        }

        public void AllocateEmployee(GeneralSeat reqseat, GeneralSeatDTO seat)
        {
            //Check if employee exists in employeetable
            var emp = _employeerepo.GetById(seat.EmployeeId);
            if (emp == null)
            {
                throw new Exception("Employee not found.");
            }

            emp.IsAllocated = true;
            _employeerepo.Update(emp);

            reqseat.EmployeeId = seat.EmployeeId;
            _repository.Update(reqseat);
            _repository.Save();
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
                    var allocatedSeatsInFloor = GetAllocatedSeatsReport().Where(f=>reqFloorNumber.Contains(f.FloorNumber));
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
            var reqFacility = _frepository.GetAll().Where(f => f.FacilityId == filterType.FacilityId);
            if (reqFacility == null)
            {
                throw new Exception("No facilities found");
            }
            return reqFacility.ToList();
        }
        public IEnumerable<Facility> ApplyFloorFilter(FilterDTO filterType)
        {
            var reqFloor = _frepository.GetAll().Where(f => f.FloorNumber == filterType.FloorNumber);
            if (reqFloor == null)
            {
                throw new Exception("No facilities in entered floor found");
            }
            return reqFloor.ToList();
        }
       
}
}
