using AutoMapper;
using WebStore.Dto;
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
    }
}
