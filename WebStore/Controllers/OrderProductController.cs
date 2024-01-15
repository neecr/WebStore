using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;
using WebStore.Services.Interfaces;

namespace WebStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductController : Controller
    {
        private readonly IOrderProductService _orderProductService;

        public OrderProductController(IOrderProductService orderProductService)
        {
            _orderProductService = orderProductService;
        }

        [HttpGet("{orderId:int}")]
        [ProducesResponseType(200, Type = typeof(ICollection<OrderProduct>))]
        public IActionResult GetOrderProducts(int orderId)
        {
            var orderProducts = _orderProductService.GetOrderProducts(orderId);
            return Ok(orderProducts);
        }
    }
}
