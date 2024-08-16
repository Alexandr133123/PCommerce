using Microsoft.EntityFrameworkCore;
using PCommerce.Application.Interfaces;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Services
{
    public class ProductService:IProductService
    {
        private readonly PCommerceDbContext _context;

        public  ProductService(PCommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
           var products = await _context.Products.Include(p => p.Categories).ToListAsync();

            var productsDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Categories = p.Categories.Select(c => new CategoryDto
                {
                    Id = c.Id,

                    Name = c.Name,

                }).ToList(),
            }).ToList();
            return productsDtos;
        }

        public async  Task AddProductAsync(Product product)
        {
          await _context.Products.AddAsync(product);
          await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product productToUpdate)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id ==productToUpdate.Id);

            if (existingProduct == null)
            {
                throw new Exception($"Product with ID {productToUpdate.Id} not found");
            }

            existingProduct.Name = productToUpdate.Name;

            existingProduct.Price = productToUpdate.Price;

            await _context.SaveChangesAsync();

        }
        
        public async Task RemoveProductAsync(int id)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                throw new Exception($"Product with ID {id} not found");
            }

            _context.Remove(existingProduct);

            await _context.SaveChangesAsync();
        }



       

    }
}
