using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetCategoryById(int caterogyId);   
        public List<Product> GetProductsByCategory(string categoryName);
        public List<Category> GetCategories();

        public bool IsCategoryExists(int categoryId);
    }
}
