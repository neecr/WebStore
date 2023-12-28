using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class OrderProduct
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Order")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
