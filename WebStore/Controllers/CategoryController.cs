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
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("{categoryName}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        public IActionResult GetProductsByCategory(string categoryName)
        {
            categoryName =
                string.Concat(char.ToUpper(categoryName[0]), categoryName[1..].ToLower())
                    .Trim(); // put the string in titlecase
            var products = _mapper.Map<List<ProductDto>>(_categoryService.GetProductsByCategory(categoryName));
            return Ok(products);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Category>))]
        public IActionResult GetCategory()
        {
            var categories = _mapper.Map<List<CategoryDto>>(_categoryService.GetCategories());
            return Ok(categories);
        }
    }
}
