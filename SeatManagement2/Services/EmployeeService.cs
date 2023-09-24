using System;
using System.Collections.Generic;
using System.Linq;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;

namespace SeatManagement2.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
       
        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
           
        }

        public List<Employee> GetAllEmployees(int pageNumber, int pageSize)
        {
            //int _pageNumber = 1;
            //int _pageSize = 2;
            var paginatedEmployeeList= _repository
                .GetAll()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return paginatedEmployeeList;
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var item = new Employee
            {
                EmployeeName = employeeDTO.EmployeeName,
                DepartmentId = employeeDTO.DepartmentId
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteEmployee(int employeeId)
        {
            var item = _repository.GetById(employeeId);
            if (item == null)
            {
                throw new ResourceNotFoundException("Could not find employee");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }
        
    }
}

