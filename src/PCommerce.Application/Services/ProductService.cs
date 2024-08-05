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
    public class ProductService : IProductService
    {
        private readonly PCommerceDbContext _context;

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
            
        }
        public void AddProduct(Product product)
        {
            _context.Add(product);
        }
    }
}
