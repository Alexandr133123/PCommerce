using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Infrastructure.Data;

public sealed class PCommerceDbContext : IdentityDbContext<Account>
{

    public  DbSet<Product> Products { get; set; }
    public PCommerceDbContext(DbContextOptions<PCommerceDbContext> options) : base(options)
    {
        
        Database.EnsureCreated();
    }
    
}