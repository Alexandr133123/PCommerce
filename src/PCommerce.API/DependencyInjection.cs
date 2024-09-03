using FluentValidation;
using Microsoft.AspNetCore.Identity;
using PCommerce.API.Infrastructure;
using PCommerce.Application.Services;
using PCommerce.Application.Validators;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddSwaggerGen();
        
        services.AddIdentity<Account, IdentityRole>()
            .AddEntityFrameworkStores<PCommerceDbContext>();
        services.AddExceptionHandler<ExceptionHandler>();
        services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();
       

        return services;
    }
}