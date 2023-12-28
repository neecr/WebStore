namespace WebStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
