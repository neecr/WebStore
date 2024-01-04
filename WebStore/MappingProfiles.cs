using AutoMapper;
using WebStore.Dto;
using WebStore.Models;

namespace WebStore
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductByIdDto>();
            CreateMap<Category, CategoryDto>();
        }   
    }
}
