using WebStore.Exceptions;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void DeleteCustomer(int customerId)
        {
            if (!_customerRepository.IsCustomerExists(customerId))
                throw new NotFoundException("The customer with such ID is not found.");
            
            _customerRepository.DeleteCustomer(customerId);
        }
    }
}
