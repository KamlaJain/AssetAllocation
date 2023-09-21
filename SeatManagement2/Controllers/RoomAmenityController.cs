using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomAmenityController : ControllerBase
    {
        private readonly IRoomAmenityService _roomAmenityService;

        public RoomAmenityController(IRoomAmenityService roomAmenityService)
        {
            _roomAmenityService = roomAmenityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_roomAmenityService.GetAllRoomAmenities());
        }

        [HttpPost]
        public IActionResult Add(RoomAmenityDTO roomAmenityDTO)
        {
            try
            {
                _roomAmenityService.AddRoomAmenity(roomAmenityDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{roomAmenityId}")]
        public IActionResult Delete(int roomAmenityId)
        {
            try
            {
                _roomAmenityService.DeleteRoomAmenity(roomAmenityId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //SET THESE METHODS AS QUERY PARAMETERS - FOLLOWING RESTAPI NAMING GUIDELINES
        //SET CUSTOM EXCEPTIONS
        [HttpPut("AllocateAmenity")]
        public IActionResult AllocateToRoom(RoomAmenityDTO roomAmenityDTO)
        {
            try
            {
                _roomAmenityService.AllocateRoomAmenity(roomAmenityDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("DeallocateAmenity")]
        public IActionResult DeallocateFromRoom(RoomAmenityDTO roomAmenityDTO)
        {
            try
            {
                _roomAmenityService.DeallocateRoomAmenity(roomAmenityDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
