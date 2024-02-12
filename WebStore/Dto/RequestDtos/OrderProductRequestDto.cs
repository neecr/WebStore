namespace WebStore.Dto.RequestDtos
{
    public class OrderProductRequestDto
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Count { get; set; }
    }
}
