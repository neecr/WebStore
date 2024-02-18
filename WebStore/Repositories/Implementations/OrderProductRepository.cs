using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    public class OrderProductRepository : IOrderProductRepository
    {
        private readonly DataContext _context;

        public OrderProductRepository(DataContext context)
        {
            _context = context;
        }
        
        public List<OrderProduct> GetOrderProducts(int orderId)
        {
            return (from op in _context.OrderProduct
                join p in _context.Products on op.ProductId equals p.ProductId
                join o in _context.Orders on op.OrderId equals o.OrderId
                where op.OrderId == orderId
                select new OrderProduct
                {
                    Product = p,
                    Count = op.Count,
                    Order = o
                }).AsNoTracking().ToList();
        }

        public OrderProduct CreateOrderProduct(OrderProduct orderProduct)
        {
            _context.OrderProduct.Add(orderProduct);
            _context.SaveChanges();
            return orderProduct;
        }

        public OrderProduct UpdateOrderProduct(int orderProductId, OrderProduct orderProduct)
        {
            var existingOrderProduct = _context.OrderProduct.Find(orderProductId)!;

            existingOrderProduct.Count = orderProduct.Count;
            existingOrderProduct.OrderId = orderProduct.OrderId;
            existingOrderProduct.ProductId = orderProduct.ProductId;

            _context.SaveChanges();

            return existingOrderProduct;
        }

        public void DeleteOrderProduct(int orderProductId)
        {
            var existingOrderProduct = _context.OrderProduct.Find(orderProductId);

            _context.OrderProduct.Remove(existingOrderProduct!);
            _context.SaveChanges();
        }
        public bool IsOrderProductExists(int orderProductId)
        {
            return _context.OrderProduct.AsNoTracking().Any(op => op.OrderProductId == orderProductId);
        }
    }
}
