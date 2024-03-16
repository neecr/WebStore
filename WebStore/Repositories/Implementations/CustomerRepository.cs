using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context)
        {
            _context = context;
        }
        public bool IsCustomerExists(int customerId)
        {
            return _context.Customers.AsNoTracking().Any(c => c.CustomerId == customerId);
        }

        public void DeleteCustomer(int customerId)
        {
            var existingCustomer = _context.Customers.Find(customerId);
            
            _context.Customers.Remove(existingCustomer!);
            _context.SaveChanges();
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == customerId)!;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.AsNoTracking().OrderBy(c => c.CustomerId).ToList();
        }

        public Customer CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        
        public Customer UpdateCustomer(int customerId, Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customerId)!;
            
            existingCustomer.FirstName = customer.FirstName;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.CustomerId = customerId;

            _context.SaveChanges();
            return existingCustomer;
        }
    }
}
