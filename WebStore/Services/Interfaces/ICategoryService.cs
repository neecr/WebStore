using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface ICategoryService
    {
        public ICollection<Product> GetProductsByCategory(string categoryName);

        public ICollection<Category> GetCategories();
    }
}
