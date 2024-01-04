using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int productId);
    }
}
