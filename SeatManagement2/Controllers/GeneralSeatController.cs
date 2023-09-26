using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs;
using Microsoft.AspNetCore.Authorization;
using SeatManagement2.Exceptions;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralSeatController : ControllerBase
    {
        private readonly IGeneralSeatService _generalSeatService;
        private readonly IReportService _reportService;

        public GeneralSeatController(IGeneralSeatService generalSeatService, IReportService reportService)
        {
            _generalSeatService = generalSeatService;
            _reportService = reportService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_generalSeatService.GetAllGeneralSeats());
        }

        [HttpPost]
        public IActionResult Add(GeneralSeatDTO generalSeatDTO)
        {
            try
            {
                _generalSeatService.AddGeneralSeat(generalSeatDTO);
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

        [HttpDelete("{seatId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int seatId)
        {
            try
            {
                _generalSeatService.DeleteGeneralSeat(seatId);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult Update([FromQuery] bool toAllocate, GeneralSeatDTO seat)
        {
            try
            {
                ///api/GeneralSeat?toAllocate=true
                _generalSeatService.UpdateEmployeeSeatAllocationStatus(toAllocate, seat);
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
        public IActionResult GetReports([FromQuery] bool isallocatedreport, [FromQuery] int filterChoice, [FromQuery] FilterDTO filterType)
        {
            try
            {
                //api/generalseat/reports/?isallocatedreport=true
                return Ok(_reportService.GenerateSeatsReport(isallocatedreport, filterChoice, filterType));

            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}


