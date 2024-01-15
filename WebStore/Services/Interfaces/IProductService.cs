using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductByIdDto GetProductById(int productId);
        void CreateProduct(ProductRequestDto product);
    }
}
