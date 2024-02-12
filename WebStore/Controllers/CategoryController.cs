using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [Route("getCategoryById/{categoryId:int}")]
        [HttpGet]
        public IActionResult GetCategoryById(int categoryId)
        {
            var products = _categoryService.GetCategoryById(categoryId);
            return Ok(products);
        }

        [Route("getProductsInCategory/{categoryName}")]
        [HttpGet]
        public IActionResult GetProductsByCategory(string categoryName)
        {
            var products = _categoryService.GetProductsByCategory(categoryName);
            return Ok(products);
        }
        
        [Route("getCategories")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }
        
        [Route("create")]
        [HttpPost]
        public IActionResult CreateCategory(CategoryRequestDto categoryRequestDto)
        {
            var modelCategory = _categoryService.CreateCategory(categoryRequestDto);
            return Ok(modelCategory);
        }
        
        [Route("edit/{categoryId:int}")]
        [HttpPut]
        public IActionResult UpdateCategory(int categoryId, CategoryUpdateDto categoryUpdateDto)
        {
            var category = _categoryService.UpdateCategory(categoryId, categoryUpdateDto);
            category.CategoryId = categoryId;
            return Ok(category);
        }
        
        [Route("delete/{categoryId:int}")]
        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return NoContent();
        }
    }
}
