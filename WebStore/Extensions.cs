using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebStore.Repositories.Implementations;
using WebStore.Repositories.Interfaces;
using WebStore.Services.Implementations;
using WebStore.Services.Interfaces;

namespace WebStore;

public static class Extensions
{
    public static IServiceCollection AddRepositoriesAndServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderProductRepository, OrderProductRepository>();
        services.AddScoped<IOrderProductService, OrderProductService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        
        services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
        services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
        services.AddValidatorsFromAssemblyContaining<OrderValidator>();
        services.AddValidatorsFromAssemblyContaining<OrderProductValidator>();
        services.AddValidatorsFromAssemblyContaining<ProductValidator>();
        services.AddValidatorsFromAssemblyContaining<UserValidator>();
        
        return services;
    }
    
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CategoryValidator>();
        services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
        services.AddValidatorsFromAssemblyContaining<OrderValidator>();
        services.AddValidatorsFromAssemblyContaining<OrderProductValidator>();
        services.AddValidatorsFromAssemblyContaining<ProductValidator>();
        services.AddValidatorsFromAssemblyContaining<UserValidator>();
        
        return services;
    }
    
    public static IServiceCollection AddJwt(this IServiceCollection services, JwtOptions jwtOptions)
    {
        services.AddAuthentication(configOptions =>
        {
            configOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            configOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            configOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwtBearerOptions =>
        {
            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(jwtOptions!.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true
            };
        });
        
        return services;
    }
    
}