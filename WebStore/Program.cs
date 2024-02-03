using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebStore.Data;
using WebStore.Repositories.Implementations;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Implementations;
using WebStore.Services.Interfaces;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            builder.Services.AddControllers();
            builder.Services.AddTransient<Seed>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderProductRepository, OrderProductRepository>();
            builder.Services.AddScoped<IOrderProductService, OrderProductService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"));
            });
            
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            var app = builder.Build();

            if (args.Length == 1 && args[0].ToLower() == "seeddata")
                Seed.SeedData(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandler>();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
