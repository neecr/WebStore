using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface IOrderProductService
    {
        public List<OrderProductDto> GetOrderProducts(int orderId);
        public OrderProduct CreateOrderProduct(OrderProductRequestDto orderProductRequestDto);
        public OrderProduct UpdateOrderProduct(int orderProductId, OrderProductUpdateDto orderProductUpdateDto);
        public void DeleteOrderProduct(int orderProductId);
        public void Validate(OrderProduct orderProduct);
    }
}
