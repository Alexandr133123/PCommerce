using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Services;
using PCommerce.Application.Validators;
using System.Reflection;

namespace PCommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();

        services.AddTransient<ICategoryService, CategoryService>();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient<ValidateService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}