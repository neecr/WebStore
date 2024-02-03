using WebStore.Data;
using WebStore.Exceptions;
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
            return _context.Customers.Any(c => c.CustomerId == customerId);
        }

        public void DeleteCustomer(int customerId)
        {
            var existingCustomer = _context.Customers.Find(customerId);
            
            if (existingCustomer == null)
                throw new NotFoundException("The customer with such ID is not found.");

            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();
        }
        
    }
}
