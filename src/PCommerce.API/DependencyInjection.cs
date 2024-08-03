using Microsoft.AspNetCore.Identity;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddIdentity<Account, IdentityRole>()
            .AddEntityFrameworkStores<PCommerceDbContext>();

        return services;
    }
}