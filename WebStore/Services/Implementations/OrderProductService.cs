using AutoMapper;
using WebStore.Dto;
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
    }
}
