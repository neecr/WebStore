using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDto GetCategoryById(int caterogyId);
        public List<ProductDto> GetProductsByCategory(string categoryName);
        public List<CategoryDto> GetCategories();
        public Category CreateCategory(CategoryRequestDto categoryRequestDto);
        public Category UpdateCategory(int categoryId, CategoryUpdateDto categoryUpdateDto);
        public bool IsCategoryExists(int categoryId);
    }
}
