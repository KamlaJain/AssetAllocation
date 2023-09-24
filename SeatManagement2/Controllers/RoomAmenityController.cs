using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs;
using NuGet.DependencyResolver;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Policy = "AdminOnly")]
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

        [HttpPatch]
        public IActionResult UpdateAmenity(RoomAmenityDTO roomAmenityDTO)
        {
            try
            {
                _roomAmenityService.UpdateAmenitiesInRoom(roomAmenityDTO);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
       
    }
}
