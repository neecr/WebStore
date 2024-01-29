using AutoMapper;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryDto GetCategoryById(int caterogyId)
        {
            return _mapper.Map<CategoryDto>(_categoryRepository.GetCategoryById(caterogyId));
        }

        public List<ProductDto> GetProductsByCategory(string categoryName)
        {
            return _mapper.Map<List<ProductDto>>(_categoryRepository.GetProductsByCategory(categoryName));
        }

        public List<CategoryDto> GetCategories()
        {
            return _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
        }

        public Category CreateCategory(CategoryRequestDto categoryRequestDto)
        {
            var newcategory = _mapper.Map<Category>(categoryRequestDto);
            _categoryRepository.CreateCategory(newcategory);
            return newcategory; 
        }

        public Category UpdateCategory(int categoryId, CategoryUpdateDto categoryUpdateDto)
        {
            var updatedcategory = _mapper.Map<Category>(categoryUpdateDto);
            _categoryRepository.UpdateCategory(categoryId, updatedcategory);
            return updatedcategory;
        }

        public bool IsCategoryExists(int categoryId)
        {
            return _categoryRepository.IsCategoryExists(categoryId);
        }
    }
}
