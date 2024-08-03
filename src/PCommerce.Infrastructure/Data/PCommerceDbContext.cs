using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Infrastructure.Data;

public sealed class PCommerceDbContext : IdentityDbContext<Account>
{
    public PCommerceDbContext(DbContextOptions<PCommerceDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}