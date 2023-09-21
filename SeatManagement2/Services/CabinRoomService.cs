using System;
using System.Collections.Generic;
using System.Linq;
using SeatManagement2.DTOs;
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
           var item = new CabinRoom
            {
                CabinNumber = cabinRoomDTO.CabinNumber,
                FacilityId = cabinRoomDTO.FacilityId,
            };
            Console.WriteLine("test");
            Console.WriteLine(item);

            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteCabinRoom(int cabinId)
        {
            var item = _repository.GetById(cabinId);
            if (item == null)
            {
                throw new Exception("Cabin does not exist");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }
        public void AllocateEmployeeToCabin(AllocationDTO cabin)
        {
            var reqCabin = _repository.GetAll().FirstOrDefault(c => c.CabinNumber == cabin.SeatNumber && c.FacilityId == cabin.FacilityId);
            if (reqCabin == null)
            {
                throw new Exception("Cabin not found.");
            }
            if (reqCabin.EmployeeId != null)
            {
                throw new Exception("Cabin is already allocated.");
            }
            var emp = _employeerepo.GetById(cabin.EmployeeId);
            if (emp == null)
            {
                throw new Exception("Employee not found.");
            }
            reqCabin.EmployeeId = cabin.EmployeeId;

            emp.IsAllocated = true;
            _employeerepo.Update(emp);

            _repository.Update(reqCabin);
            _repository.Save();
        }

        public void DeallocateEmployeeFromCabin(AllocationDTO cabin)
        {
            var reqCabin = _repository.GetAll().FirstOrDefault(c => c.CabinNumber == cabin.SeatNumber && c.FacilityId == cabin.FacilityId);
            if (reqCabin == null)
            {
                throw new Exception("Cabin not found.");
            }
            if (reqCabin.EmployeeId == null)
            {
                throw new Exception("Cabin is not allocated to any employee.");
            }

            var emp = _employeerepo.GetAll().FirstOrDefault(e => e.EmployeeId == reqCabin.EmployeeId);
            if (emp == null)
            {
                throw new Exception("Employee not found.");
            }
            reqCabin.EmployeeId = null;

            emp.IsAllocated = false;
            _employeerepo.Update(emp);

            _repository.Update(reqCabin);
            _repository.Save();
        }


    }
}
