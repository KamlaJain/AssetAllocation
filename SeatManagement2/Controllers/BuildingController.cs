using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.Exceptions;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : Controller
    {
        private readonly IBuildingService _building;

        public BuildingController(IBuildingService ibuilding)
        {
            _building = ibuilding;
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

       
        [HttpPatch]
        public IActionResult EditBuilding(string buildingcode, BuildingLookUpDTO updatedBuilding)
        {
            try
            {
                _building.EditBuilding(buildingcode, updatedBuilding);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            /* catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }*/
        }

    }
}



