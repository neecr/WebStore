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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("getProducts")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        
        [Route("getProductsById/{productId:int}")]
        [HttpGet]
        public IActionResult GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            return Ok(product);
        }
        
        [Route("create")]
        [HttpPost]
        public IActionResult CreateProduct(ProductRequestDto productRequestDto)
        {
            var modelProduct = _productService.CreateProduct(productRequestDto);
            return Ok(modelProduct);
        }
        
        [Route("edit/{productId:int}")]
        [HttpPut]
        public IActionResult UpdateProduct(int productId, ProductUpdateDto productUpdateDto)
        {
            var product = _productService.UpdateProduct(productId, productUpdateDto);
            return Ok(product);
        }

        [Route("delete/{productId:int}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            return NoContent();
        }
    }
}
