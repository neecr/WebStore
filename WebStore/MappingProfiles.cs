using AutoMapper;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;

namespace WebStore
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Product, ProductByIdDto>();

            CreateMap<ProductRequestDto, Product>();
            CreateMap<Product, ProductRequestDto>();
            
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<Product, ProductUpdateDto>();
            
            CreateMap<CategoryRequestDto, Category>();
            CreateMap<Category, CategoryRequestDto>();

            CreateMap<CategoryUpdateDto, Category>();
            CreateMap<Category, CategoryUpdateDto>();

            CreateMap<Order, OrderRequestDto>();
            CreateMap<OrderRequestDto, Order>();

            CreateMap<Order, OrderUpdateDto>();
            CreateMap<OrderUpdateDto, Order>();

            CreateMap<OrderProduct, OrderProductRequestDto>();
            CreateMap<OrderProductRequestDto, OrderProduct>();
            
            CreateMap<OrderProduct, OrderProductUpdateDto>();
            CreateMap<OrderProductUpdateDto, OrderProduct>();

            CreateMap<User, UserRequestDto>();
            CreateMap<UserRequestDto, User>();

            CreateMap<CustomerRequestDto, Customer>();
            CreateMap<CustomerUpdateDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<ProductByIdDto, Product>();
            
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            
            CreateMap<Order, OrderDto>();
            CreateMap<OrderProduct, OrderProductDto>();
        }
    }
}
