using WebStore.Data;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Product> GetProductsByCategory(string categoryName)
        {
            return _context.Products.Where(p => p.Category.Name == categoryName).OrderBy(p => p.ProductId).ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.CategoryId).ToList();
        }
    }
}
