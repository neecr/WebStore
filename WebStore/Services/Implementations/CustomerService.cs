using AutoMapper;
using FluentValidation;
using WebStore.Dto;
using WebStore.Dto.RequestDtos;
using WebStore.Dto.UpdateDtos;
using WebStore.Exceptions;
using WebStore.Models;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Interfaces;

namespace WebStore.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator<Customer> _validator;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IValidator<Customer> validator)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public void DeleteCustomer(int customerId)
        {
            if (!_customerRepository.IsCustomerExists(customerId))
                throw new NotFoundException("The customer with such ID is not found.");

            _customerRepository.DeleteCustomer(customerId);
        }

        public void Validate(Customer customer)
        {
            var result = _validator.Validate(customer);
            if (result.IsValid) return;
            throw new ValidationException($"Validation error: {result}");
        }

        public CustomerDto GetCustomer(int customerId)
        {
            if (!_customerRepository.IsCustomerExists(customerId))
                throw new NotFoundException("The customer with such ID is not found.");
            
            return _mapper.Map<CustomerDto>(_customerRepository.GetCustomer(customerId));
        }
        public List<CustomerDto> GetCustomers()
        {
            return _mapper.Map<List<CustomerDto>>(_customerRepository.GetCustomers());
        }

        public Customer CreateCustomer(CustomerRequestDto customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            Validate(newCustomer);
            _customerRepository.CreateCustomer(newCustomer);
            return newCustomer;
        }

        public Customer UpdateCustomer(int customerId, CustomerUpdateDto customer)
        {
            if (!_customerRepository.IsCustomerExists(customerId))
                throw new NotFoundException("The customer with such ID is not found.");
            
            var updatedCustomer = _mapper.Map<Customer>(customer);
            Validate(updatedCustomer);
            _customerRepository.UpdateCustomer(customerId, updatedCustomer);
            updatedCustomer.CustomerId = customerId;
            return updatedCustomer;
        }
    }
}