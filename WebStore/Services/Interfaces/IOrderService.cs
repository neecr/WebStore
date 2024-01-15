using WebStore.Dto;

namespace WebStore.Services.Interfaces
{
    public interface IOrderService
    {
        public List<OrderDto> GetOrders();
        public List<OrderDto> GetCustomerOrders(int customerId);
    }
}
