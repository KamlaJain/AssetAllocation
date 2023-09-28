using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinRoomController : ControllerBase
    {
        private readonly ICabinRoomService _cabinRoomService;
        private readonly IReportService _reportService;

        public CabinRoomController(ICabinRoomService cabinRoomService, IReportService reportService)
        {
            _cabinRoomService = cabinRoomService;
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_cabinRoomService.GetAllCabinRooms());
        }

        [HttpPost]
        public IActionResult Add(CabinRoomDTO cabinRoomDTO)
        {
            try
            {
                _cabinRoomService.AddCabinRoom(cabinRoomDTO);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cabinId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int cabinId)
        {
            try
            {
                _cabinRoomService.DeleteCabinRoom(cabinId);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch("{cabinId}")]
        public IActionResult Update(int cabinId, int? employeeId)
        {
            try
            {
                _cabinRoomService.UpdateEmployeeCabinAllocationStatus(cabinId, employeeId);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Reports")]
        public IActionResult GetReports([FromQuery] bool isUnallocatedReport, [FromQuery] string? cityCode, [FromQuery] string? buildingCode, [FromQuery] string? facilityName, [FromQuery] int? floorNumber)
        {
            try
            {
                return Ok(_reportService.GenerateCabinsReport(isUnallocatedReport, cityCode, buildingCode, facilityName, floorNumber));

            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
