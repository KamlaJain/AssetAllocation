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
            catch
            {
                return BadRequest();
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
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("allocate")]
        public IActionResult Allocate(AllocationDTO seat)
        {
            try
            {
                _cabinRoomService.AllocateEmployeeToCabin(seat);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("deallocate")]
        public IActionResult Deallocate(AllocationDTO seat)
        {
            try
            {
                _cabinRoomService.DeallocateEmployeeFromCabin(seat);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
