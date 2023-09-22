using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralSeatController : ControllerBase
    {
        private readonly IGeneralSeatService _generalSeatService;

        public GeneralSeatController(IGeneralSeatService generalSeatService)
        {
            _generalSeatService = generalSeatService;
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{seatId}")]
        public IActionResult Delete(int seatId)
        {
            try
            {
                _generalSeatService.DeleteGeneralSeat(seatId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch]
        public IActionResult Update(GeneralSeatDTO seat)
        {
            try
            {
                _generalSeatService.UpdateEmployeeSeatAllocationStatus(seat);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Reports")]
        public IActionResult GetFreeSeats()
        {
            try
            {
                return Ok(_generalSeatService.UnallocatedSeatsReport());
                //return Ok(_generalSeatService.GetAllocatedSeatsReport());


            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("report2")]
        public IActionResult GetFreeSeats2()
        {
            try
            {
                //return Ok(_generalSeatService.UnallocatedSeatsReport());
                return Ok(_generalSeatService.AllocatedSeatsReport());


            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }
    }
}
