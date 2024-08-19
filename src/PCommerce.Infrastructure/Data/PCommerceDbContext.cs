using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCommerce.Infrastructure.Data.Models;
using System.Reflection;

namespace PCommerce.Infrastructure.Data;

public sealed class PCommerceDbContext : IdentityDbContext<Account>
{
    
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public PCommerceDbContext(DbContextOptions<PCommerceDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}