using AutoMapper;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
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

        public Product CreateProduct(int categoryId, ProductRequestDto product)
        {
            var newproduct = _mapper.Map<Product>(product);
            _productRepository.CreateProduct(categoryId, newproduct);
            return newproduct;
        }

        public Product UpdateProduct(int productId, ProductUpdateDto product)
        {
            var updatedproduct = _mapper.Map<Product>(product);
            _productRepository.UpdateProduct(productId, updatedproduct);
            updatedproduct.ProductId = productId;
            return updatedproduct;
        }

        public bool IsProductExists(int productId)
        {
            return _productRepository.IsProductExists(productId);
        }
    }
}
