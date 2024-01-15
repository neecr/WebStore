using WebStore.Dto;
using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface IOrderProductRepository
    {
        public List<OrderProduct> GetOrderProducts(int orderId);
    }
}
