using Microsoft.AspNetCore.Identity;
using PCommerce.API.Controllers;
using PCommerce.API.Infrastructure;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddGrpc();
        
        services.AddTransient<ProductController>();
        services.AddTransient<CategoryController>();

        services.AddExceptionHandler<ExceptionHandler>();

        services.AddControllers();

        services.AddSwaggerGen();
        
        services.AddIdentity<Account, IdentityRole>()
            .AddEntityFrameworkStores<PCommerceDbContext>();

        return services;
    }
}