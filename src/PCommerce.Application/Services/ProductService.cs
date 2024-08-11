﻿using Microsoft.EntityFrameworkCore;
using PCommerce.Application.Interfaces;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly PCommerceDbContext _context;
        public ProductService(PCommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProduct (Product product)
        {
            if(product == null)
            {
                throw new Exception();
            }
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProduct(int id, Product updatedProduct)
        {
            var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (product == null)
            {
                throw new Exception();
            }
            product.Price = updatedProduct.Price;
            product.Name = updatedProduct.Name;
            await _context.SaveChangesAsync();
        }
    }
}
