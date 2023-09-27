using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
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
    public class FacilityController : Controller
    {

        private readonly IFacilityService _facility;


        public FacilityController(IFacilityService ifacility)
        {
           _facility = ifacility;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_facility.IndexFacility());

        }
        [HttpPost]
        public IActionResult Add(FacilityDTO facilityDTO)
        {
            try
            {
                _facility.AddFacility(facilityDTO);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }   
        
        [HttpDelete("{facId}")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Delete(int facId)
        {
            try
            {
                _facility.DeleteFacility(facId);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

