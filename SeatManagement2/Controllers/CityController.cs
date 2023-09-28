using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        public readonly ICityService _city;
        public CityController(ICityService icity)
        {
            _city = icity;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_city.IndexCity());
        }

        [HttpPost]
        public IActionResult Add(CityLookUpDTO cityLookUpDTO)
        {
            try
            {
                _city.AddCity(cityLookUpDTO);
                return Ok();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
