using WebStore.Data;
using WebStore.Models;

namespace WebStore
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        private void SeedDataContext()
        {
            if (!dataContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Vegetables" },
                    new Category { Name = "Fruits" },
                };

                dataContext.Categories.AddRange(categories);
                dataContext.SaveChanges();
            }

            if (!dataContext.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product { Name = "Tomato", Price = 3.5, CategoryId = 1 },
                    new Product { Name = "Banana", Price = 1.7, CategoryId = 2 },
                };

                dataContext.Products.AddRange(products);
                dataContext.SaveChanges();
            }

            if (!dataContext.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer { FirstName = "Alan", LastName = "Peterson", Email = "gustave_hay@gmail.com" },
                    new Customer { FirstName = "Jennifer", LastName = "Hernandez", Email = "ciara2015@gmail.com" },
                };

                dataContext.Customers.AddRange(customers);
                dataContext.SaveChanges();
            }

            if (!dataContext.Orders.Any())
            {
                var orders = new List<Order>
                {
                    new Order { Date = DateTime.Now, CustomerId = 1 },
                    new Order { Date = DateTime.Now, CustomerId = 2 },
                };

                dataContext.Orders.AddRange(orders);
                dataContext.SaveChanges();
            }

            if (!dataContext.OrderProduct.Any())
            {
                var orderProducts = new List<OrderProduct>
                {
                    new OrderProduct { Count = 5, ProductId = 1, OrderId = 1 },
                    new OrderProduct { Count = 3, ProductId = 2, OrderId = 2 },
                };

                dataContext.OrderProduct.AddRange(orderProducts);
                dataContext.SaveChanges();
            }
        }

        public static void SeedData(IHost app)
        {
            var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

            using var scope = scopedFactory.CreateScope();
            var service = scope.ServiceProvider.GetService<Seed>();
            service.SeedDataContext();
        }
    }
}
