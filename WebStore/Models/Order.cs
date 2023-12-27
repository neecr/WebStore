namespace WebStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer? Customer { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
