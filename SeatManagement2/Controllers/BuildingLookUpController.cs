using Microsoft.AspNetCore.Mvc;
using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingLookUpController : Controller
    {
        private readonly IBuildingService _building;

        public BuildingLookUpController(IBuildingService ibuilding)
        {
            _building = ibuilding;
        }

        [HttpGet]
        public IActionResult IndexBuilding()
        {
            return Ok(_building.IndexBuilding());
        }

        [HttpPost]
        public IActionResult AddBuilding(BuildingLookUpDTO buildingLookUpDTO)
        {
            try
            {
                _building.AddBuilding(buildingLookUpDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteBuilding(BuildingLookUpDTO buildingLookUpDTO)
        {
            try
            {
                _building.DeleteBuilding(buildingLookUpDTO);
                return Ok();
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}



