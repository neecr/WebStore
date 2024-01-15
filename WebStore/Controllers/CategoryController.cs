using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Dto;
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
    }
}
