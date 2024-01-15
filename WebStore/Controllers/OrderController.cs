using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
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
    }
}
