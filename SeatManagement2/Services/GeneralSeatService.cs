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

       
       
}
}
