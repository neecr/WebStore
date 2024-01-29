using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Dto;
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
                join c in _context.Customers on o.CustomerId equals c.CustomerId
                where op.OrderId == orderId
                select new OrderProduct
                {
                    Product = p,
                    Count = op.Count,
                    Order = o
                }).ToList();
        }

        public OrderProduct CreateOrderProduct(int productId, int orderId, OrderProduct orderProduct)
        {
            orderProduct.ProductId = productId;
            orderProduct.OrderId = orderId;

            _context.OrderProduct.Add(orderProduct);
            _context.SaveChanges();
            return orderProduct;
        }

        public OrderProduct UpdateOrderProduct(int orderProductId, OrderProduct orderProduct)
        {
            var existingOrderProduct = _context.OrderProduct.Find(orderProductId);
            if (existingOrderProduct == null) return null;

            existingOrderProduct.Count = orderProduct.Count;
            existingOrderProduct.OrderId = orderProduct.OrderId;
            existingOrderProduct.ProductId = orderProduct.ProductId;

            _context.SaveChanges();

            return existingOrderProduct;
        }
    }
}
