using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Interfaces;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnallocatedSeatController : Controller
    {
        private readonly IUnallocatedSeatsReport _allocated;

        public UnallocatedSeatController(IUnallocatedSeatsReport allocated)
        {
            _allocated = allocated;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_allocated.GetUnallocatedSeatsReport());
        }
    }
}