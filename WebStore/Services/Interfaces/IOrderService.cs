using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IOrderService
    {
        public List<OrderDto> GetOrders();
        public List<OrderDto> GetCustomerOrders(int customerId);
        public Order CreateOrder(int customerId, OrderRequestDto orderRequestDto);
        public Order UpdateOrder(int orderId, OrderUpdateDto orderUpdateDto);

        public void DeleteOrder(int orderId);
        public bool IsOrderExists(int orderId);
    }
}
