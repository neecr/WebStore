using WebStore.Dto;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDto GetCategoryById(int caterogyId);
        public List<ProductDto> GetProductsByCategory(string categoryName);

        public List<CategoryDto> GetCategories();
    }
}
