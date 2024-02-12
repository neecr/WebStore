using AutoMapper;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Exceptions;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;


        public OrderService(IOrderRepository orderRepository, IMapper mapper, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public List<OrderDto> GetOrders()
        {
            return _mapper.Map<List<OrderDto>>(_orderRepository.GetOrders());
        }

        public List<OrderDto> GetCustomerOrders(int customerId)
        {
            if (!_customerRepository.IsCustomerExists(customerId)) 
                throw new NotFoundException("The customer with such ID is not found.");
            
            return _mapper.Map<List<OrderDto>>(_orderRepository.GetCustomerOrders(customerId));
        }

        public Order CreateOrder(OrderRequestDto orderRequestDto)
        {
            if(!_customerRepository.IsCustomerExists(orderRequestDto.CustomerId))
                throw new NotFoundException("The customer with such ID is not found.");
            
            var newOrder = _mapper.Map<Order>(orderRequestDto);
            _orderRepository.CreateOrder(newOrder);
            return newOrder;
        }

        public Order UpdateOrder(int orderId, OrderUpdateDto orderUpdateDto)
        {
            if(!_orderRepository.IsOrderExists(orderId))
                throw new NotFoundException("The order with such ID is not found.");
            if(!_customerRepository.IsCustomerExists(orderUpdateDto.CustomerId))
                throw new NotFoundException("The customer with such ID is not found.");
            
            var updatedOrder = _mapper.Map<Order>(orderUpdateDto);
            _orderRepository.UpdateOrder(orderId, updatedOrder);
            updatedOrder.OrderId = orderId;
            return updatedOrder;
        }

        public void DeleteOrder(int orderId)
        {
            if(!_orderRepository.IsOrderExists(orderId))
                throw new NotFoundException("The order with such ID is not found.");
            
            _orderRepository.DeleteOrder(orderId);
        }
    }
}
