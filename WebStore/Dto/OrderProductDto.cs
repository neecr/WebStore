namespace WebStore.Dto
{
    public class OrderProductDto
    {
        public CustomerDto Customer { get; set; }
        
        public ProductByIdDto Product { get; set; }
        
        public int Count { get; set; }
    }
}
