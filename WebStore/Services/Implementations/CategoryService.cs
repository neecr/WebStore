using AutoMapper;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Exceptions;
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
            var category = _categoryRepository.GetCategoryById(caterogyId);
            if (category == null) throw new NotFoundException("The category with such ID is not found.");
            
            return _mapper.Map<CategoryDto>(category);
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
            var newCategory = _mapper.Map<Category>(categoryRequestDto);
            _categoryRepository.CreateCategory(newCategory);
            return newCategory; 
        }

        public Category UpdateCategory(int categoryId, CategoryUpdateDto categoryUpdateDto)
        {
            if (!_categoryRepository.IsCategoryExists(categoryId))
                throw new NotFoundException("The category with such ID is not found");
            
            var updatedCategory = _mapper.Map<Category>(categoryUpdateDto);
            _categoryRepository.UpdateCategory(categoryId, updatedCategory);
            return updatedCategory;
        }

        public void DeleteCategory(int categoryId)
        {
            if (!_categoryRepository.IsCategoryExists(categoryId))
                throw new NotFoundException("The category with such ID is not found");
            
            _categoryRepository.DeleteCategory(categoryId);
        }
    }
}
