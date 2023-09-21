using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocatedSeatController : Controller
    {
        private readonly IAllocatedSeatsReport _allocated;

        public AllocatedSeatController(IAllocatedSeatsReport allocated)
        {
            _allocated = allocated;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_allocated.GetAllocatedSeatsReport());
        }
    }
}