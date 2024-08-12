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
    public class ProductService : IProductService
    {
        private readonly PCommerceDbContext _dbContext;
        public ProductService (PCommerceDbContext productService)
        {
            _dbContext = productService;
        }
        public void Add(Product product)
        {
            _dbContext.Add(product);
            _dbContext.SaveChanges();
        }
        public void Update(Product product)
        {
            _dbContext.Update(product);
            _dbContext.SaveChanges();
        }
        public void Remove(Product product)
        {
            _dbContext.Remove(product);
            _dbContext.SaveChanges();
        }
        public List<Product> GetAllProduct()
        {
            return _dbContext.Products.ToList();
        }
    }
}
