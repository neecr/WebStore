namespace WebStore.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        public bool IsCustomerExists(int customerId);
    }
}