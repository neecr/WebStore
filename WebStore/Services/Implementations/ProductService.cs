using AutoMapper;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<ProductDto> GetProducts()
        {
            return _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());
        }

        public ProductByIdDto GetProductById(int productId)
        {
            return _mapper.Map<ProductByIdDto>(_productRepository.GetProductById(productId));
        }

        public void CreateProduct(ProductRequestDto product)
        {
            _productRepository.CreateProduct(_mapper.Map<Product>(product));
        }
    }
}
