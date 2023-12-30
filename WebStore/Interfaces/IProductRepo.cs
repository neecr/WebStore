using WebStore.Models;

namespace WebStore.Interfaces
{
    public interface IProductRepo
    {
        ICollection<Product> GetProducts();
    }
}
