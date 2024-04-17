using System.Security.Principal;
using Web_API_Topstyles.Domain.DTOs.UserDTOs;
using Web_API_Webshop.Core.Helpers;

namespace Web_API_Topstyles.Core.Interfaces
{
    public interface IUserService
    {
        Task<ResultResponse<string>> Register(RegisterUserDTO user);

        Task<ResultResponse<UserDTO>> Login(LoginUserDTO user);

        Task<ResultResponse<string>> LogOut(IIdentity identity);

        Task<string> GetUserIdFromClaims(IIdentity identity);
    }
}
