using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class OrderProductController : Controller
    {
        private readonly IOrderProductService _orderProductService;
        public OrderProductController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }
        
        [Route("getOrderProducts/{orderId:int}")]
        [HttpGet]
        public IActionResult GetOrderProducts(int orderId)
        {
            var orderProducts = _orderProductService.GetOrderProducts(orderId);
            return Ok(orderProducts);
        }
        
        [Route("create")]
        [HttpPost]
        public IActionResult CreateOrderProduct(OrderProductRequestDto orderProductRequestDto)
        {
            var modelProduct = _orderProductService.CreateOrderProduct(orderProductRequestDto);
            return Ok(modelProduct);
        }

        [Route("edit/{orderProductId:int}")]
        [HttpPut]
        public IActionResult UpdateOrderProduct(int orderProductId, OrderProductUpdateDto orderProductUpdateDto)
        {
            var orderProduct = _orderProductService.UpdateOrderProduct(orderProductId, orderProductUpdateDto);
            return Ok(orderProduct);
        }
        
        [Route("delete/{orderProductId:int}")]
        [HttpDelete]
        public IActionResult DeleteOrderProduct(int orderProductId)
        {
            _orderProductService.DeleteOrderProduct(orderProductId);
            return NoContent();
        }
    }
}
