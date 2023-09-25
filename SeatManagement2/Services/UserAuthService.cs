using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using SeatManagement2.Models;
using System.Security.Claims;
using SeatManagement2.Interfaces;
using SeatManagement2.Exceptions;

namespace SeatManagement2.Services
{
    public class UserAuthService : IUserAuth
    {
        public UserAuthService(){ }

        public ClaimsPrincipal AuthenticateUser(UserCredentials credentials)
        {
            if (credentials.Username == "admin" && credentials.Password == "admin")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                var claimsPrincipal = new ClaimsPrincipal(identity);

                return claimsPrincipal;

            }
            else
            {
                throw new UnauthorizedUserException("Unauthorized User");
            }
        }
    }
}
