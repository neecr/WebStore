namespace WebStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
