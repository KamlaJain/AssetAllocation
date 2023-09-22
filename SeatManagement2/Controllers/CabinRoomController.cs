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

        public CabinRoomController(ICabinRoomService cabinRoomService)
        {
            _cabinRoomService = cabinRoomService;
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

        [HttpDelete]
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
    }
}
