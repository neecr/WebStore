using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public ICollection<Product> GetProductsByCategory(string categoryName);
        
        public ICollection<Category> GetCategories();
    }
}
