using Microsoft.EntityFrameworkCore;
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

        public Category GetCategoryById(int caterogyId)
        {
            return _context.Categories.AsNoTracking().FirstOrDefault(c => c.CategoryId == caterogyId)!;
        }

        public List<Product> GetProductsByCategory(string categoryName)
        {
            return _context.Products.AsNoTracking().Where(p => p.Category.Name == categoryName).
                OrderBy(p => p.ProductId).ToList();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.AsNoTracking().OrderBy(c => c.CategoryId).ToList();
        }

        public Category CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category UpdateCategory(int categoryId, Category category)
        {
            var existingCategory = _context.Categories.Find(categoryId)!;

            existingCategory.Name = category.Name;

            _context.SaveChanges();

            return existingCategory;
        }

        public void DeleteCategory(int categoryId)
        {
            var existingCategory = _context.Categories.Find(categoryId)!;
            
            _context.Categories.Remove(existingCategory);
            _context.SaveChanges();
        }

        public bool IsCategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.CategoryId == categoryId);
        }
    }
}
