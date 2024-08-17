using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCommerce.Infrastructure.Data.Models;
using System.Reflection;

namespace PCommerce.Infrastructure.Data;

public sealed class PCommerceDbContext : IdentityDbContext<Account>
{

    public  DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public PCommerceDbContext(DbContextOptions<PCommerceDbContext> options) : base(options)
    {
       
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}