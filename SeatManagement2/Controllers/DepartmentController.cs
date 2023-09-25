using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using Microsoft.AspNetCore.Authorization;
using SeatManagement2.Exceptions;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {

        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_departmentService.GetAllDepartments());
        }

        [HttpPost]
        public IActionResult Add(string departmentName)
        {
            try
            {
                _departmentService.AddDepartment(departmentName);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{deptId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int deptId)
        {
            try
            {
                _departmentService.DeleteDepartment(deptId);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}



