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
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [Route("getOrders")]
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }
        
        [Route("getCustomersOrders/{customerId:int}")]
        [HttpGet]
        public IActionResult GetCustomerOrders(int customerId)
        {
            var orders = _orderService.GetCustomerOrders(customerId);
            return Ok(orders);
        }
        
        [Route("create")]
        [HttpPost]
        public IActionResult CreateOrder(OrderRequestDto orderRequestDto)
        {
            var modelOrder = _orderService.CreateOrder(orderRequestDto);
            return Ok(modelOrder);
        }
        
        [Route("edit/{orderId:int}")]
        [HttpPut]
        public IActionResult UpdateOrder(int orderId, OrderUpdateDto productUpdateDto)
        {
            var order = _orderService.UpdateOrder(orderId, productUpdateDto);
            return Ok(order);
        }
        
        [Route("delete/{orderId:int}")]
        [HttpDelete]
        public IActionResult DeleteOrderProduct(int orderId)
        {
            _orderService.DeleteOrder(orderId);
            return NoContent();
        }
    }
}
