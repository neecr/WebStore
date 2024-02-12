using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProductById(int productId);
        void CreateProduct(Product product);
        Product UpdateProduct(int productId, Product product);
        void DeleteProduct(int productId);
        public bool IsProductExists(int productId);
    }
}
