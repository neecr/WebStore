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
            var orders = _context.Orders.Where(o => o.CustomerId == customerId).
                OrderBy(o => o.OrderId).ToList();
            return orders;
        }

        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public Order UpdateOrder(int orderId, Order order)
        {
            var existingOrder = _context.Orders.Find(orderId)!;

            existingOrder.Date = order.Date;
            existingOrder.CustomerId = order.CustomerId;

            _context.SaveChanges();

            return existingOrder;
        }

        public void DeleteOrder(int orderId)
        {
            var existingOrder = _context.Orders.Find(orderId);

            _context.Orders.Remove(existingOrder!);
            _context.SaveChanges();
        }

        public bool IsOrderExists(int orderId)
        {
            return _context.Orders.Any(o => o.OrderId == orderId);
        }
    }
}
