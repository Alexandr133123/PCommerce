using Microsoft.Extensions.DependencyInjection;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Services;

namespace PCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services = new ServiceCollection()
        .AddTransient<IProductService, ProductService>

        return services;
    }
}