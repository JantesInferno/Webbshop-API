using AutoMapper;
using Web_API_Topstyles.Domain.DTOs.UserDTOs;
using Web_API_Topstyles.Domain.Entities;
using Web_API_Topstyles.Domain.Identity;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Web_API_Topstyles.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<User, RegisterUserDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
