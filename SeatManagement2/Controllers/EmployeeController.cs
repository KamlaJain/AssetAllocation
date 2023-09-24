using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Interfaces;


namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] int pageNumber,[FromQuery] int pageSize)
        {
            return Ok(_employeeService.GetAllEmployees(pageNumber,pageSize));
        }

        [HttpPost]
        public IActionResult Add(EmployeeDTO employeeDTO)
        {
            try
            {
                _employeeService.AddEmployee(employeeDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{employeeId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int employeeId)
        {
            try
            {
                _employeeService.DeleteEmployee(employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


