using Azure.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Web_API_Topstyles.Core.Interfaces;
using Web_API_Topstyles.Domain.DTOs.UserDTOs;

namespace Web_API_Topstyles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("/api/user/login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IResult> Login(LoginUserDTO userDTO)
        {
            if (userDTO == null)
                return Results.Problem("Fyll i samtliga inloggningsuppgifter", statusCode: 400);

            var result = await _userService.Login(userDTO);

            if (!result.Success)
                return Results.Problem(result.ErrorMessage, statusCode: 401);

            return Results.Ok(result.Data);
        }

        [Route("/api/user/register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IResult> Register(RegisterUserDTO userDTO)
        {
            if (userDTO == null)
                return Results.Problem("Fyll i samtliga användaruppgifter", statusCode: 400);

            var result = await _userService.Register(userDTO);

            if (!result.Success)
                return Results.Problem(result.ErrorMessage, statusCode: 401);

            return Results.Ok(result.Data);
        }

        [Route("/api/user/logout")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IResult> LogOut()
        {
            if (User.Identity == null)
                return Results.Problem("Du är inte inloggad", statusCode: 401);

            var result = await _userService.LogOut(User.Identity);

            if (!result.Success)
                return Results.Problem(result.ErrorMessage, statusCode: 401);

            return Results.Ok(result.Data);
        }
    }
}
