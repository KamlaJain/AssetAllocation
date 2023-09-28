using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class GeneralSeatService : IGeneralSeatService
    {
        private readonly IRepository<GeneralSeat> _repository;
        private readonly IRepository<Employee> _employeerepo;
        private readonly IRepository<Facility> _faciityrepo;



        public GeneralSeatService(IRepository<GeneralSeat> repository, IRepository<Employee> employeerepo, IRepository<Facility> faciityrepo)
        {
            _repository = repository;
            _employeerepo = employeerepo;
            _faciityrepo = faciityrepo;
        }

        public List<GeneralSeat> GetAllGeneralSeats()
        {
            return _repository.GetAll().ToList();
        }

        public void AddGeneralSeat(GeneralSeatDTO generalSeatDTO)
        {
            if (!_faciityrepo.GetAll().Any(f => f.FacilityId == generalSeatDTO.FacilityId))
            {
                throw new ResourceNotFoundException("The Facility does not exist.");
            }
            if (_repository.GetAll().Any(s => s.SeatNumber == generalSeatDTO.SeatNumber && s.FacilityId == generalSeatDTO.FacilityId))
            {
                throw new BadRequestException("Seat with the same SeatNumber and FacilityId already exists.");
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
                throw new ResourceNotFoundException("Could not find general seat");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }

        public void UpdateEmployeeSeatAllocationStatus(int seatId, int? employeeId)
        {
            var reqseat = _repository.GetAll().FirstOrDefault(s => s.SeatId==seatId) ?? throw new ResourceNotFoundException("Seat not found.");
            if (employeeId.HasValue)
            {
                AllocateEmployee(reqseat, employeeId);
            }
            else
            {
                DeallocateEmployee(reqseat);
            }
        }
        public void AllocateEmployee(GeneralSeat reqseat, int? employeeId)
        {
            var employee = _employeerepo.GetAll().Where(e => e.EmployeeId == employeeId).FirstOrDefault() ?? throw new ResourceNotFoundException("Employee not found");
            if (reqseat.EmployeeId.HasValue) { throw new BadRequestException("Employee already allocated"); }
            reqseat.EmployeeId = employeeId;
            employee.IsAllocated = true;

            _repository.Update(reqseat);
            _employeerepo.Update(employee);
            _repository.Save();

        }
        public void DeallocateEmployee(GeneralSeat reqseat)
        {
            var employee = _employeerepo.GetAll().Where(e=>e.EmployeeId == reqseat.EmployeeId).FirstOrDefault() ?? throw new ResourceNotFoundException("Employee not found");
            if(!reqseat.EmployeeId.HasValue) { throw new BadRequestException("Employee is not currently allocated"); }
            reqseat.EmployeeId = null;
            employee.IsAllocated= false;

            _repository.Update(reqseat);
            _employeerepo.Update(employee);
            _repository.Save();
        }
    }
}


/*public void DeallocateEmployee(GeneralSeat reqseat, int employeeId)
{

    var emp = _employeerepo.GetAll().FirstOrDefault(e => e.EmployeeId == employeeId);
    if (emp == null)
    {
        throw new ResourceNotFoundException("Employee not found.");
    }
    if (!reqseat.EmployeeId.HasValue)
    {
        throw new BadRequestException("No employee in seat to deallocate");
    }

    emp.IsAllocated = false;
    _employeerepo.Update(emp);

    reqseat.EmployeeId = null;
    _repository.Update(reqseat);
    _repository.Save();

}

public void AllocateEmployee(GeneralSeat reqseat, GeneralSeatDTO seat)
{
    if (reqseat.EmployeeId.HasValue)
    {
        throw new BadRequestException("Already allocated seat");
    }
    var emp = _employeerepo.GetById((int)seat.EmployeeId!);
    if (emp == null)
    {
        throw new ResourceNotFoundException("Employee not found.");
    }
    if (emp.IsAllocated == true)
    {
        throw new BadRequestException("Employee already allocated");
    }

    emp.IsAllocated = true;
    _employeerepo.Update(emp);
    _employeerepo.Save();

    reqseat.EmployeeId = seat.EmployeeId;
    _repository.Update(reqseat);
    _repository.Save();
}*/