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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            }
        }
        [HttpPatch]
        public IActionResult Update(AllocationDTO seat)
        {
            try
            {
                _generalSeatService.UpdateEmployeeAllocationStatus(seat);
                return Ok();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }
        }
        /*[HttpPost("deallocate")]
        public IActionResult Deallocate(AllocationDTO seat)
        {
            try
            {
                _generalSeatService.DeallocateEmployeeFromSeat(seat);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }*/
    }
}
