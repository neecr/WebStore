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
    public class OrderProductService : IOrderProductService
    {
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public OrderProductService(IOrderProductRepository orderProductRepository, IMapper mapper, IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderProductRepository = orderProductRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public List<OrderProductDto> GetOrderProducts(int orderId)
        {
            if(!_orderRepository.IsOrderExists(orderId))
                throw new NotFoundException("The order with such ID is not found.");
            
            return _mapper.Map<List<OrderProductDto>>(_orderProductRepository.GetOrderProducts(orderId));
        }

        public OrderProduct CreateOrderProduct(OrderProductRequestDto orderProductRequestDto)
        {
            if (!_productRepository.IsProductExists(orderProductRequestDto.ProductId))
                throw new NotFoundException("The product with such ID is not found.");
            if (!_orderRepository.IsOrderExists(orderProductRequestDto.OrderId))
                throw new NotFoundException("The order with such ID is not found.");
            
            var newOrderProduct = _mapper.Map<OrderProduct>(orderProductRequestDto);
            _orderProductRepository.CreateOrderProduct(newOrderProduct);
            return newOrderProduct;
        }

        public OrderProduct UpdateOrderProduct(int orderProductId, OrderProductUpdateDto orderProductUpdateDto)
        {
            if(!_orderProductRepository.IsOrderProductExists(orderProductId))
                throw new NotFoundException("The pair of order and product with such ID is not found.");
            if(!_orderRepository.IsOrderExists(orderProductUpdateDto.OrderId))
                throw new NotFoundException("The order with such ID is not found.");
            if(!_productRepository.IsProductExists(orderProductUpdateDto.ProductId))
                throw new NotFoundException("The product with such ID is not found.");
            
            var updatedOrderProduct = _mapper.Map<OrderProduct>(orderProductUpdateDto);
            _orderProductRepository.UpdateOrderProduct(orderProductId, updatedOrderProduct);
            updatedOrderProduct.OrderProductId = orderProductId;
            return updatedOrderProduct;
        }

        public void DeleteOrderProduct(int orderProductId)
        {
            if(!_orderProductRepository.IsOrderProductExists(orderProductId))
                throw new NotFoundException("The pair of order and product with such ID is not found.");
            
            _orderProductRepository.DeleteOrderProduct(orderProductId);
        }
    }
}
