using WebStore.Models;

namespace WebStore.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public bool IsCustomerExists(int customerId);
        public void DeleteCustomer(int customerId);
    }
}
