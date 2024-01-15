using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public List<Order> GetOrders(); 
        public List<Order> GetCustomerOrders(int customerId);
    }
}
