using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProductById(int productId);
        
        void CreateProduct(int categoryId, Product product);
        Product UpdateProduct(int productId, Product product);
    }
}
