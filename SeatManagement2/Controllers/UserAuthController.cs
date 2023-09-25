using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Exceptions;
using SeatManagement2.Interfaces;
using SeatManagement2.Models;
using System.Security.Claims;

namespace SeatManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : Controller
    {
        private readonly IUserAuth userAuth;

        public UserAuthController(IUserAuth userAuth)
        {
            this.userAuth = userAuth;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials credentials)
        {
            try
            {
                var claimsPrincipal = userAuth.AuthenticateUser(credentials);
                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
                return Ok();
            }
            catch (UnauthorizedUserException)
            {
                await HttpContext.SignOutAsync("MyCookieAuth");
                return Unauthorized();
            }
        }
    }
}
