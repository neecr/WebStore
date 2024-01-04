using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICollection<Product> GetProductsByCategory(string categoryName)
        {
            return _categoryRepository.GetProductsByCategory(categoryName);
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryRepository.GetCategories();
        }
    }
}
