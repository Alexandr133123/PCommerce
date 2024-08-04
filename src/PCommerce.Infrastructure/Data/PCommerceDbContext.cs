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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {                  
     
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.Price)
                .IsRequired();
                
        }
    }
}