using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs;
using SeatManagement2.Services;

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
        public IActionResult Index()
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cabinId}")]
        public IActionResult Delete(int cabinId)
        {
            try
            {
                _cabinRoomService.DeleteCabinRoom(cabinId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult Update(CabinRoomDTO seat)
        {
            try
            {
                _cabinRoomService.UpdateEmployeeCabinAllocationStatus(seat);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Reports")]
        public IActionResult GetReports([FromQuery] bool isallocatedreport, [FromQuery] int filterChoice, [FromQuery] FilterDTO filterType)
        {
            try
            {
                //api/generalseat/reports/?isallocatedreport=true
                return Ok(_reportService.GenerateCabinsReport(isallocatedreport, filterChoice, filterType));

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
