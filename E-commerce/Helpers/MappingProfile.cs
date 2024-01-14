using AutoMapper;
using E_commerce.Dtos;
using E_commerce.Models;
namespace E_commerce.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ProductDto, Product>()
                .ForMember(src => src.Image,opt => opt.Ignore())
                .ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
