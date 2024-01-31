using Microsoft.AspNetCore.Mvc;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Order>))]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{customerId:int}")]
        [ProducesResponseType(200, Type = typeof(ICollection<Order>))]
        public IActionResult GetCustomerOrders(int customerId)
        {
            var orders = _orderService.GetCustomerOrders(customerId);
            return Ok(orders);
        }
        
        [HttpPost("{customerId:int}")]
        public IActionResult CreateOrder(int customerId, OrderRequestDto orderRequestDto)
        {
            var modelOrder = _orderService.CreateOrder(customerId, orderRequestDto);
            return Ok(modelOrder);
        }
        
        [HttpPut("{orderId:int}")]
        public IActionResult UpdateOrder(int orderId, OrderUpdateDto productUpdateDto)
        {
            var order = _orderService.UpdateOrder(orderId, productUpdateDto);
            return Ok(order);
        }
    }
}
