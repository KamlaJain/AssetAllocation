using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.DTOs;
using NuGet.DependencyResolver;
using Microsoft.AspNetCore.Authorization;
using SeatManagement2.Exceptions;

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
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
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
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
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
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
       
    }
}
