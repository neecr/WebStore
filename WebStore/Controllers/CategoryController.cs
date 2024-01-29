using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet("{categoryId:int}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        public IActionResult GetProductsById(int categoryId)
        {
            var products = _categoryService.GetCategoryById(categoryId);
            return Ok(products);
        }

        [HttpGet("{categoryName}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        public IActionResult GetProductsByCategory(string categoryName)
        {
            var products = _categoryService.GetProductsByCategory(categoryName);
            return Ok(products);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
        public IActionResult GetCategory()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryRequestDto categoryRequestDto)
        {
            var modelCategory = _categoryService.CreateCategory(categoryRequestDto);
            return Ok(modelCategory);
        }

        [HttpPut("{categoryId:int}")]
        public IActionResult UpdateCategory(int categoryId, CategoryUpdateDto categoryUpdateDto)
        {
            var category = _categoryService.UpdateCategory(categoryId, categoryUpdateDto);
            category.CategoryId = categoryId;
            return Ok(category);
        }
    }
}
