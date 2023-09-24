using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using System.Security.Claims;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : Controller
    {
        private readonly IConfiguration configuration;
        public UserAuthController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody]UserCredentials credentials)
        {
            if(credentials.Username=="admin" && credentials.Password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var claimsPrincipal= new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return Ok();

            }
            else
            {
                await HttpContext.SignOutAsync("MyCookieAuth");
                return Unauthorized();
            }
        }
    }
}
