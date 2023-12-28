using Microsoft.EntityFrameworkCore;
using WebStore.Models;


namespace WebStore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product) // Указание связи один-к-одному с моделью Product
                .WithMany(p => p.OrderProducts) // Указание обратной связи с моделью Product
                .HasForeignKey(op => op.ProductId); // Указание внешнего ключа в модели Product
        }
    }
}
