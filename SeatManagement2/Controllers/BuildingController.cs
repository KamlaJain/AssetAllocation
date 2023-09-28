using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _building;

        public BuildingController(IBuildingService building)
        {
            _building = building;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_building.GetAllBuildings());
        }

        [HttpPost]
        public IActionResult AddBuilding(BuildingLookUpDTO buildingLookUpDTO)
        {
            try
            {
                _building.AddBuilding(buildingLookUpDTO);
                return Ok();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}



