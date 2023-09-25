using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.Services;
using Microsoft.AspNetCore.Authorization;
using SeatManagement2.Exceptions;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenityController : Controller
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
        public IActionResult Add(string amenityName)
        {
            try
            {
                _amenityService.AddAmenity(amenityName);
                return Ok();
            }
            catch(ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpDelete("{amenityId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int amenityId)
        {
            try
            {
                _amenityService.DeleteAmenity(amenityId);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}