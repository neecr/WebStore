using WebStore.Dto;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IOrderProductService
    {
        public List<OrderProductDto> GetOrderProducts(int orderId);
    }
}
