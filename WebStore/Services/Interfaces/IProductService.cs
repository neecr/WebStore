using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductDto> GetProducts();
        ProductByIdDto GetProductById(int productId);
        Product CreateProduct(ProductRequestDto product);
        Product UpdateProduct(int productId, ProductUpdateDto product);
        void DeleteProduct(int productId);
    }
}
