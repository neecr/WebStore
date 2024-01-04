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

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }

        public Product GetProductById(int productId)
        {
            return (from p in _context.Products
                join c in _context.Categories on p.CategoryId equals c.CategoryId
                where p.ProductId == productId
                select new Product
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Category = c
                }).FirstOrDefault()!;
        }
    }
}
