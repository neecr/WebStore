using Microsoft.IdentityModel.Tokens;
using WebStore.Data;
using WebStore.Exceptions;
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

        public Category GetCategoryById(int caterogyId)
        {
            var category = _context.Categories.FirstOrDefault(c => c.CategoryId == caterogyId);
            if (category == null) throw new Exception("The category with such ID is not found.");
            return category;
        }

        public List<Product> GetProductsByCategory(string categoryName)
        {
            var products = _context.Products.Where(p => p.Category.Name == categoryName).
                OrderBy(p => p.ProductId).ToList();
            if (products.IsNullOrEmpty()) throw new NotFoundException("The category with such name is not found.");
            return products;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.OrderBy(c => c.CategoryId).ToList();
        }

        public Category CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category UpdateCategory(int categoryId, Category category)
        {
            var existingCategory = _context.Categories.Find(categoryId);
            if (existingCategory == null)
                throw new NotFoundException("The category with such ID is not found");

            existingCategory.Name = category.Name;

            _context.SaveChanges();

            return existingCategory;
        }

        public bool IsCategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.CategoryId == categoryId);
        }
    }
}
