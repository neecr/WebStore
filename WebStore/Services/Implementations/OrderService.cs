using AutoMapper;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;


        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public List<OrderDto> GetOrders()
        {
            return _mapper.Map<List<OrderDto>>(_repository.GetOrders());
        }

        public List<OrderDto> GetCustomerOrders(int customerId)
        {
            return _mapper.Map<List<OrderDto>>(_repository.GetCustomerOrders(customerId));
        }

        public Order CreateOrder(int customerId, OrderRequestDto orderRequestDto)
        {
            var neworder = _mapper.Map<Order>(orderRequestDto);
            _repository.CreateOrder(customerId, neworder);
            return neworder;
        }

        public Order UpdateOrder(int orderId, OrderUpdateDto orderUpdateDto)
        {
            var updatedorder = _mapper.Map<Order>(orderUpdateDto);
            _repository.UpdateOrder(orderId, updatedorder);
            return updatedorder;
        }

        public bool IsOrderExists(int orderId)
        {
            return _repository.IsOrderExists(orderId);
        }
    }
}
