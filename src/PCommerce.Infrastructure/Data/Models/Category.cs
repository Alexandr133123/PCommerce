using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Infrastructure.Data.Models
{
    public class Category
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public List<Product> Products { get; set; }
       
    }

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder )
        {
            builder.HasKey( x => x.Id );

            builder.Property( x => x.Name )
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
