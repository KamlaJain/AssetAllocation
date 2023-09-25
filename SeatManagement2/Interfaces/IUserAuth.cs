using Microsoft.AspNetCore.Mvc;
using SeatManagement2.Models;
using System.Security.Claims;

namespace SeatManagement2.Interfaces
{
    public interface IUserAuth
    {
        ClaimsPrincipal AuthenticateUser(UserCredentials credentials);
    }
}
