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
    public class AmenityTypeController : Controller
    {
        private readonly IAmenityTypeService _amenityService;

        public AmenityTypeController(IAmenityTypeService amenityService)
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       
    }
}