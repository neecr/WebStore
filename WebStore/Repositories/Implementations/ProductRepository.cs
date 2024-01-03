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
    }
}
