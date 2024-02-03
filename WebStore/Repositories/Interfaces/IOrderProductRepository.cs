using WebStore.Dto;
using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IOrderProductRepository
    {
        public List<OrderProduct> GetOrderProducts(int orderId);
        public OrderProduct CreateOrderProduct(int productId, int orderId, OrderProduct orderProduct);
        public OrderProduct UpdateOrderProduct(int orderProductId, OrderProduct orderProduct);
        public void DeleteOrderProduct(int orderProductId);
    }
}
