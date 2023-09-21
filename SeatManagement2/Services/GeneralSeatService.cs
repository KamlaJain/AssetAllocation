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

        public GeneralSeatService(IRepository<GeneralSeat> repository, IRepository<Facility> facilityrepository, IRepository<Employee> employeerepo)
        {
            _repository = repository;
            _frepository = facilityrepository;
            _employeerepo = employeerepo;
        }

        public List<GeneralSeat> GetAllGeneralSeats()
        {
            return _repository.GetAll().ToList();
        }

        public void AddGeneralSeat(GeneralSeatDTO generalSeatDTO)
        {
            //validation to check if same seatnumber exists for a facility
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

        
        
        public void AllocateEmployeeToSeat(AllocationDTO seat)
        {

           
            var reqseat = _repository.GetAll().FirstOrDefault(s => s.SeatNumber == seat.SeatNumber && s.FacilityId==seat.FacilityId);
            if (reqseat == null)
            {
                throw new Exception("Seat not found.");
            }
            if (reqseat.EmployeeId != null)
            {
                throw new Exception("Seat is already allocated.");
            }
            var emp = _employeerepo.GetById(seat.EmployeeId);
            if (emp == null)
            {
                throw new Exception("Employee not found.");
            }
            reqseat.EmployeeId = seat.EmployeeId;

            emp.IsAllocated = true;
            _employeerepo.Update(emp);


            _repository.Update(reqseat);
            _repository.Save();

        }
        public void DeallocateEmployeeFromSeat(AllocationDTO seat)
        {
            var reqseat = _repository.GetAll().FirstOrDefault(s => s.SeatNumber == seat.SeatNumber && s.FacilityId == seat.FacilityId);
            if (reqseat == null)
            {
                throw new Exception("Seat not found.");
            }
            if (reqseat.EmployeeId == null)
            {
                throw new Exception("Seat is not allocated to any employee.");
            }

            var emp = _employeerepo.GetAll().FirstOrDefault(s => s.EmployeeId == seat.EmployeeId);
            if (emp == null)
            {
                throw new Exception("Employee not found.");
            }
            reqseat.EmployeeId = null;

            emp.IsAllocated = false;
            _employeerepo.Update(emp);

            _repository.Update(reqseat);
            _repository.Save();

        }
    }
}
