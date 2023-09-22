using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using SeatManagement2.DTOs;
using SeatManagement2.Models;
using SeatManagement2.Interfaces;
using SeatManagement2.Services;

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
            catch
            {
                return BadRequest();
            }
        }   
        
        [HttpDelete]
        public IActionResult Delete(int facId)
        {
            try
            {
                _facility.DeleteFacility(facId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        //api/facility/{id}/amenity
       /* [HttpPost("{facilityId}")]
        public IActionResult AddAmenityToFacility(int facilityId, int amenityId)
        {
            try
            {
                _facility.AddAmenityToFacility(facilityId, amenityId);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }*/
        
    }

}

