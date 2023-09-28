using global::SeatManagement2.Interfaces;
using global::SeatManagement2.Models;
using SeatManagement2.Exceptions;

namespace SeatManagement2.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<DepartmentLookUp> _repository;

        public DepartmentService(IRepository<DepartmentLookUp> repository)
        {
            _repository = repository;
        }

        public List<DepartmentLookUp> GetAllDepartments()
        {
            return _repository.GetAll().ToList();
        }

        public void AddDepartment(string departmentName)
        {
            var reqDept = _repository.GetAll().FirstOrDefault(c => c.DepartmentName == departmentName);
            if (reqDept != null)
            {
                throw new BadRequestException("City already exists");
            }
            var item = new DepartmentLookUp
            {
                DepartmentName = departmentName
            };
            _repository.Add(item);
            _repository.Save();
        }

        public void DeleteDepartment(int deptId)
        {
            var item = _repository.GetById(deptId);
            if (item == null)
            {
                throw new ResourceNotFoundException("Department not Found");
            }
            else
            {
                _repository.Delete(item);
                _repository.Save();
            }
        }
    }
}


