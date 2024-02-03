﻿using Microsoft.AspNetCore.Mvc;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Product>))]
        public IActionResult GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }
        
        [HttpGet("{productId:int}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        public IActionResult GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        
        [HttpPost("{categoryId:int}")]
        public IActionResult CreateProduct(int categoryId, ProductRequestDto productRequestDto)
        {
            var modelProduct = _productService.CreateProduct(categoryId, productRequestDto);
            return Ok(modelProduct);
        }

        [HttpPut("{productId:int}")]
        public IActionResult UpdateProduct(int productId, ProductUpdateDto productUpdateDto)
        {
            var product = _productService.UpdateProduct(productId, productUpdateDto);
            return Ok(product);
        }

        [HttpDelete("{productId:int}")]
        public IActionResult DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
            return NoContent();
        }
    }
}
