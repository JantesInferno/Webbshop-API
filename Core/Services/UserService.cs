using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;
using Web_API_Topstyles.Core.Interfaces;
using Web_API_Topstyles.Domain.DTOs.UserDTOs;
using Web_API_Topstyles.Domain.Identity;
using Web_API_Webshop.Core.Helpers;

namespace Web_API_Topstyles.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<ResultResponse<UserDTO>> Login(LoginUserDTO user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);

            if (result.Succeeded)
            {
                var userData = await _userManager.FindByNameAsync(user.Username);
                var userDTO = _mapper.Map<UserDTO>(userData);

                return new ResultResponse<UserDTO>(data: userDTO);
            }
            return new ResultResponse<UserDTO>(errorMessage: "Felaktigt användarnamn/lösenord");
        }

        public async Task<ResultResponse<string>> LogOut(IIdentity userIdentity)
        {
            if (userIdentity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();

                return new ResultResponse<string>(data: "Du har loggat ut");
            }

            return new ResultResponse<string>(errorMessage: "Du är inte inloggad");
        }

        public async Task<ResultResponse<string>> Register(RegisterUserDTO user)
        {
            var userIdentity = _mapper.Map<User>(user);

            var result = await _userManager.CreateAsync(userIdentity, user.Password);

            if (result.Succeeded)
            {
                return new ResultResponse<string>(data: $"Nytt konto för {user.Name} registrerat");
            }

            return new ResultResponse<string>(errorMessage: "Felaktiga användaruppgifter");
        }

        public async Task<string> GetUserIdFromClaims(IIdentity identity)
        {
            var claimsIdentity = identity as ClaimsIdentity;
            string customerIdClaim = string.Empty;

            if (claimsIdentity != null)
            {
                await Task.Run(() =>
                {
                    IEnumerable<Claim> claims = claimsIdentity.Claims;

                    customerIdClaim = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                });
            }

            return customerIdClaim;
        }
    }
}
