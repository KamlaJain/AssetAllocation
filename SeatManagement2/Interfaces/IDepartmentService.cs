using SeatManagement2.Models;

namespace SeatManagement2.Interfaces
{
    public interface IDepartmentService
    {
        List<DepartmentLookUp> GetAllDepartments();
        void AddDepartment(string departmentName);
        void DeleteDepartment(int deptId);
    }
}
