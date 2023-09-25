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
    public class AmenityController : ControllerBase
    {
        private readonly IAmenityService _amenityService;

        public AmenityController(IAmenityService amenityService)
        {
            _amenityService = amenityService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_amenityService.GetAllAmenities());
        }

        [HttpPost]
        public IActionResult AddAmenity(RoomAmenityDTO roomAmenityDTO)
        {
            try
            {
                _amenityService.AddAmenityToFacility(roomAmenityDTO);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{roomAmenityId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteAmenity(int roomAmenityId)
        {
            try
            {
                _amenityService.DeleteAmenity(roomAmenityId);
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
                _amenityService.UpdateAmenitiesInRoom(roomAmenityDTO);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
       
    }
}
