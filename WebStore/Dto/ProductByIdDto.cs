using WebStore.Models;

namespace WebStore.Dto
{
    public class ProductByIdDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public CategoryDto Category { get; set; }
    }
}
