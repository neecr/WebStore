using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public bool IsCustomerExists(int customerId);
        public void DeleteCustomer(int customerId);
        public Customer GetCustomer(int customerId);
        public List<Customer> GetCustomers();
        public Customer CreateCustomer(Customer customer);
        public Customer UpdateCustomer(int customerId, Customer customer);
    }
}
