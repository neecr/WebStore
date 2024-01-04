using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IProductService
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int productId);
    }
}
