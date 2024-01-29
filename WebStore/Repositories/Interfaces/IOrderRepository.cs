using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public List<Order> GetCustomerOrders(int customerId);
        public Order CreateOrder(int customerId, Order order);
        public Order UpdateOrder(int orderId, Order order);
        public bool IsOrderExists(int orderId);
    }
}
