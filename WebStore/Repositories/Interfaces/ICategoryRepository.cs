using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetCategoryById(int caterogyId);
        public List<Product> GetProductsByCategory(string categoryName);
        public List<Category> GetCategories();
        public Category CreateCategory(Category category);
        public Category UpdateCategory(int categoryId, Category category);
        public void DeleteCategory(int categoryId);
        public bool IsCategoryExists(int categoryId);
    }
}
