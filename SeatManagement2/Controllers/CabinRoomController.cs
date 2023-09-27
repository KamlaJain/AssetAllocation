using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs;
using SeatManagement2.Services;
using Microsoft.AspNetCore.Authorization;
using SeatManagement2.Exceptions;

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
        [HttpPatch]
        public IActionResult Update([FromQuery] bool toAllocate, CabinRoomDTO seat)
        {
            try
            {
                _cabinRoomService.UpdateEmployeeCabinAllocationStatus(toAllocate, seat);
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
        public IActionResult GetReports([FromQuery] bool isUnallocatedReport, [FromQuery] string? cityCode,  [FromQuery] string? buildingCode, [FromQuery] string? facilityName, [FromQuery] int? floorNumber)
        {
            try
            {
                //api/generalseat/reports/?isallocatedreport=true
                return Ok(_reportService.GenerateCabinsReport(isUnallocatedReport, cityCode, buildingCode, facilityName, floorNumber));

            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
