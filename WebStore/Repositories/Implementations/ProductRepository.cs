using WebStore.Data;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }

        public Product GetProductById(int productId)
        {
            var product = (from p in _context.Products
                join c in _context.Categories on p.CategoryId equals c.CategoryId
                where p.ProductId == productId
                select new Product
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Category = c
                }).FirstOrDefault();

            return product!;
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product UpdateProduct(int productId, Product product)
        {
            var existingProduct = _context.Products.Find(productId)!;
            
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;

            _context.SaveChanges();

            return existingProduct;
        }

        public void DeleteProduct(int productId)
        {
            var existingProduct = _context.Products.Find(productId)!;
            _context.Products.Remove(existingProduct);
            _context.SaveChanges();
        }

        public bool IsProductExists(int productId)
        {
            return _context.Products.Any(p => p.ProductId == productId);
        }
    }
}
