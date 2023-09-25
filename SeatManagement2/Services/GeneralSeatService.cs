using System;
using System.Collections.Generic;
using System.Linq;
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


        public GeneralSeatService(IRepository<GeneralSeat> repository, IRepository<Employee> employeerepo)
        {
            _repository = repository;
            _employeerepo = employeerepo;
        }

        public List<GeneralSeat> GetAllGeneralSeats()
        {
            return _repository.GetAll().ToList();
        }

        public void AddGeneralSeat(GeneralSeatDTO generalSeatDTO)
        {
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



        public void UpdateEmployeeSeatAllocationStatus(GeneralSeatDTO seat)
        {
            var reqseat = _repository.GetAll().FirstOrDefault(s => s.SeatNumber == seat.SeatNumber && s.FacilityId == seat.FacilityId) ?? throw new ResourceNotFoundException("Seat not found.");

            if (seat.Action == "Deallocate")
            {
                DeallocateEmployee(reqseat, seat);
            }
            else if (seat.Action == "Allocate")
            {
                AllocateEmployee(reqseat, seat);
            }
            else { throw new BadRequestException("Invalid input"); }
        }
        public void DeallocateEmployee(GeneralSeat reqseat, GeneralSeatDTO seat)
        {

            var emp = _employeerepo.GetAll().FirstOrDefault(e => e.EmployeeId == seat.EmployeeId);
            if (emp == null)
            {
                throw new ResourceNotFoundException("Employee not found.");
            }
            if (!reqseat.EmployeeId.HasValue)
            {
                throw new BadRequestException("No employee in seat to deallocate");
            }
            int empId = reqseat.EmployeeId.Value;
            var employee = _employeerepo.GetById(empId);
            employee.IsAllocated = false;
            _employeerepo.Update(employee);

            reqseat.EmployeeId = null;
            _repository.Update(reqseat);
            _repository.Save();

        }

        public void AllocateEmployee(GeneralSeat reqseat, GeneralSeatDTO seat)
        {
            if (reqseat.EmployeeId.HasValue) throw new BadRequestException("Already allocated seat");

            var emp = _employeerepo.GetById(seat.EmployeeId);
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

            reqseat.EmployeeId = seat.EmployeeId;
            _repository.Update(reqseat);
            _repository.Save();
        }



    }
}
