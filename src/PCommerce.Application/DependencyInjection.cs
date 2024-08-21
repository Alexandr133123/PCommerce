using Microsoft.Extensions.DependencyInjection;
using PCommerce.Application.interfaces;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Services;
using PCommerce.Infrastructure.Data;

namespace PCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Add new services and its interfaces to this method
        services.AddTransient<IProductService, ProductService>()
            .AddTransient<ICategoryService, CategoryService>();
        return services;
    }
}