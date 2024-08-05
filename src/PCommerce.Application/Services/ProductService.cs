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

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async  Task AddProductAsync(Product product)
        {
          await _context.Products.AddAsync(product);
          await _context.SaveChangesAsync();
        }

       

    }
}
