using AutoMapper;
using Web_API_Topstyles.Domain.DTOs.ProductDTOs;
using Web_API_Topstyles.Domain.DTOs.UserDTOs;
using Web_API_Topstyles.Domain.Entities;
using Web_API_Topstyles.Domain.Identity;

namespace Web_API_Topstyles.Domain.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
