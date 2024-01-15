using WebStore.Data;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.OrderBy(o => o.OrderId).ToList();
        }

        public List<Order> GetCustomerOrders(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerId == customerId).OrderBy(o => o.OrderId).ToList();
        }
    }
}
