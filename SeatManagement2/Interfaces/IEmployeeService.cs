using SeatManagement2.DTOs;
using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        void AddEmployee(EmployeeDTO employeeDTO);
        void DeleteEmployee(int employeeId);
    }




}
