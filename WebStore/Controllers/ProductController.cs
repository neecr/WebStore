using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Dto;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        public IActionResult GetProducts()
        {
            var products = _mapper.Map<List<ProductDto>>(_productService.GetProducts());
            return Ok(products);
        }
        
        [HttpGet("{productId:int}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        public IActionResult GetProductById(int productId)
        {
            var product = _mapper.Map<ProductByIdDto>(_productService.GetProductById(productId));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
