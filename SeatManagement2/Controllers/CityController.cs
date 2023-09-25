using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeatManagement2;
using SeatManagement2.DTOs;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;
using SeatManagement2.Services;

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

        [HttpPatch]
        public IActionResult Edit(string buildingcode, CityLookUpDTO updatedCity)
        {
            try
            {
                _city.EditCity(buildingcode, updatedCity);
                return Ok();
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
