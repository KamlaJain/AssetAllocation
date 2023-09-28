using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class CabinRoomService : ICabinRoomService
    {
        private readonly IRepository<CabinRoom> _repository;
        private readonly IRepository<Facility> _frepository;
        private readonly IRepository<Employee> _employeerepo;

        public CabinRoomService(IRepository<CabinRoom> repository, IRepository<Facility> facilityrepository, IRepository<Employee> employeerepo)
        {
            _repository = repository;
            _frepository = facilityrepository;
            _employeerepo = employeerepo;
        }

        public List<CabinRoom> GetAllCabinRooms()
        {
            return _repository.GetAll().ToList();
        }

        public void AddCabinRoom(CabinRoomDTO cabinRoomDTO)
        {
            var reqFacility = _frepository.GetAll().Any(f => f.FacilityId == cabinRoomDTO.FacilityId);
            if (!reqFacility)
            {
                throw new ResourceNotFoundException("Facility does not exist");
            }
            var reqCabin = _repository.GetAll().Any(s => s.FacilityId == cabinRoomDTO.FacilityId && s.CabinNumber == cabinRoomDTO.CabinNumber);
            if (reqCabin)
            {
                throw new BadRequestException("Cabin already exists");
            }
            var item = new CabinRoom
            {
                CabinNumber = cabinRoomDTO.CabinNumber,
                FacilityId = cabinRoomDTO.FacilityId,
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteCabinRoom(int cabinId)
        {
            var item = _repository.GetById(cabinId);
            if (item == null)
            {
                throw new ResourceNotFoundException("Cabin does not exist");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }
        public void UpdateEmployeeCabinAllocationStatus(bool toAllocate, CabinRoomDTO cabin)
        {
            var reqCabin = _repository.GetAll().FirstOrDefault(c => c.CabinNumber == cabin.CabinNumber && c.FacilityId == cabin.FacilityId);
            if (reqCabin == null)
            {
                throw new ResourceNotFoundException("Cabin not found.");
            }
            if (toAllocate)
            {
                AllocateEmployeeToCabin(reqCabin, cabin);
            }
            else
            {
                DeallocateEmployeeFromCabin(reqCabin, cabin);
            }

        }

        public void DeallocateEmployeeFromCabin(CabinRoom reqcabin, CabinRoomDTO cabin)

        {
            if (reqcabin.EmployeeId == null)
            {
                throw new BadRequestException("Cabin is not allocated to any employee.");
            }

            var emp = _employeerepo.GetAll().FirstOrDefault(e => e.EmployeeId == cabin.EmployeeId);
            if (emp == null)
            {
                throw new ResourceNotFoundException("Employee not found.");
            }
            reqcabin.EmployeeId = null;

            if (emp.IsAllocated == false)
            {
                throw new BadRequestException("Employee is not allocated");
            }
            emp.IsAllocated = false;
            _employeerepo.Update(emp);

            _repository.Update(reqcabin);
            _repository.Save();
        }

        public void AllocateEmployeeToCabin(CabinRoom reqcabin, CabinRoomDTO cabin)
        {

            if (reqcabin.EmployeeId != null)
            {
                throw new BadRequestException("Cabin is already allocated");
            }
            var emp = _employeerepo.GetById(cabin.EmployeeId);
            if (emp == null)
            {
                throw new ResourceNotFoundException("Employee not found.");
            }
            if (emp.IsAllocated == true)
            {
                throw new BadRequestException("Employee is already allocated");
            }
            reqcabin.EmployeeId = cabin.EmployeeId;

            emp.IsAllocated = true;
            _employeerepo.Update(emp);

            _repository.Update(reqcabin);
            _repository.Save();
        }
    }
}