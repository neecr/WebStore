using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Models;

namespace WebStore.Services.Interfaces
{
    public interface ICustomerService
    {
        public CustomerDto GetCustomer(int customerId);
        public List<CustomerDto> GetCustomers();
        public Customer CreateCustomer(CustomerRequestDto customer);
        public Customer UpdateCustomer(int customerId, CustomerUpdateDto customer);
        public void DeleteCustomer(int customerId);
        public void Validate(Customer customer);
        
    }
}
