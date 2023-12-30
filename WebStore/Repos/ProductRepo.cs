using WebStore.Data;
using WebStore.Interfaces;
using WebStore.Models;

namespace WebStore.Repos
{
    public class ProductRepo : IProductRepo
    {
        private readonly DataContext _context;

        public ProductRepo(DataContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(p => p.ProductId).ToList();
        }
    }
}
