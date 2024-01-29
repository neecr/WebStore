using AutoMapper;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _repository;
        private readonly IMapper _mapper;


        public OrderProductService(IOrderProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<OrderProductDto> GetOrderProducts(int orderId)
        {
            return _mapper.Map<List<OrderProductDto>>(_repository.GetOrderProducts(orderId));
        }

        public OrderProduct CreateOrderProduct(int productId, int orderId, OpRequestDto opRequestDto)
        {
            var neworderproduct = _mapper.Map<OrderProduct>(opRequestDto);
            _repository.CreateOrderProduct(productId, orderId, neworderproduct);
            return neworderproduct;
        }

        public OrderProduct UpdateOrderProduct(int orderProductId, OpUpdateDto opUpdateDto)
        {
            var updateorderproduct = _mapper.Map<OrderProduct>(opUpdateDto);
            _repository.UpdateOrderProduct(orderProductId, updateorderproduct);
            return updateorderproduct;
        }
    }
}
