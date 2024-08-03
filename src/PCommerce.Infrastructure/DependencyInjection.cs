using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PCommerce.Infrastructure.Data;

namespace PCommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MssqlConnectionString");

        services.AddDbContext<PCommerceDbContext>(options => 
            options.UseSqlServer(connectionString));

        return services;
    }
}