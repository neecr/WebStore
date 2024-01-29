using Microsoft.AspNetCore.Mvc;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : Controller
    {
        private readonly IOrderProductService _orderProductService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderProductController(IOrderProductService orderProductService, IOrderService orderService,
            IProductService productService)
        {
            _orderProductService = orderProductService;
            _orderService = orderService;
            _productService = productService;
        }

        [HttpGet("{orderId:int}")]
        [ProducesResponseType(200, Type = typeof(ICollection<OrderProduct>))]
        public IActionResult GetOrderProducts(int orderId)
        {
            var orderProducts = _orderProductService.GetOrderProducts(orderId);
            return Ok(orderProducts);
        }

        [HttpPost("{orderId:int}, {productId:int}")]
        public IActionResult CreateOrderProduct(int orderId, int productId, OpRequestDto opRequestDto)
        {
            if (!_productService.IsProductExists(productId))
            {
                return BadRequest("The product with such ID does not exist.");
            }

            if (!_orderService.IsOrderExists(orderId))
            {
                return BadRequest("The order with such ID does not exist.");
            }

            var modelProduct = _orderProductService.CreateOrderProduct(productId, orderId, opRequestDto);
            return Ok(modelProduct);
        }

        [HttpPut("{orderProductId:int}")]
        public IActionResult UpdateOrderProduct(int orderProductId, OpUpdateDto opUpdateDto)
        {
            if (!_productService.IsProductExists(opUpdateDto.ProductId))
            {
                return BadRequest("The product with such ID does not exist.");
            }
            
            if (!_orderService.IsOrderExists(opUpdateDto.OrderId))
            {
                return BadRequest("The order with such ID does not exist.");
            }
            
            var orderProduct = _orderProductService.UpdateOrderProduct(orderProductId, opUpdateDto);
            orderProduct.OrderProductId = orderProductId;
            return Ok(orderProduct);
        }
    }
}
