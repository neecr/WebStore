using WebStore.Data;
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
            
            _context.Customers.Remove(existingCustomer!);
            _context.SaveChanges();
        }
    }
}
