namespace WebStore.Services.Interfaces
{
    public interface ICustomerService
    {
        public bool IsCustomerExists(int customerId);
        public void DeleteCustomer(int customerId);
    }
}
