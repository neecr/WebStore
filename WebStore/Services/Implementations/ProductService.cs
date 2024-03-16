using AutoMapper;
using FluentValidation;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Exceptions;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Product> _validator;


        public ProductService(IProductRepository productRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IValidator<Product> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _validator = validator;
        }

        public List<ProductDto> GetProducts()
        {
            return _mapper.Map<List<ProductDto>>(_productRepository.GetProducts());
        }

        public ProductByIdDto GetProductById(int productId)
        {
            if (!_productRepository.IsProductExists(productId))
                throw new NotFoundException("The product with such ID is not found.");

            return _mapper.Map<ProductByIdDto>(_productRepository.GetProductById(productId));
        }

        public Product CreateProduct(ProductRequestDto product)
        {
            if (!_categoryRepository.IsCategoryExists(product.CategoryId))
                throw new NotFoundException("The category with such ID is not found.");

            var newProduct = _mapper.Map<Product>(product);
            Validate(newProduct);
            _productRepository.CreateProduct(newProduct);
            return newProduct;
        }

        public Product UpdateProduct(int productId, ProductUpdateDto product)
        {
            if (!_productRepository.IsProductExists(productId))
                throw new NotFoundException("The product with such ID is not found.");
            if (!_categoryRepository.IsCategoryExists(product.CategoryId))
                throw new NotFoundException("The category with such ID is not found.");
            var updatedProduct = _mapper.Map<Product>(product);
            Validate(updatedProduct);
            _productRepository.UpdateProduct(productId, updatedProduct);

            updatedProduct.ProductId = productId;
            return updatedProduct;
        }

        public void DeleteProduct(int productId)
        {
            if (!_productRepository.IsProductExists(productId))
                throw new NotFoundException("The product with such ID is not found.");
            _productRepository.DeleteProduct(productId);
        }

        public void Validate(Product product)
        {
            var result = _validator.Validate(product);
            if (result.IsValid) return;
            throw new ValidationException($"Validation error: {result}");
        }
    }
}