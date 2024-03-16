using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders();
        public List<Order> GetCustomerOrders(int customerId);
        public Order CreateOrder(Order order);
        public Order UpdateOrder(int orderId, Order order);
        public void DeleteOrder(int orderId);
        public bool IsOrderExists(int orderId);
    }
}
