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
        public async Task UpdateAsync(Product product, int productId)
        {
            var model = _dbContext.Products.FirstOrDefault(p => p.Id == productId);

            if (model == null)
            {
                throw new Exception($"Продукт с id {productId} не найден");
            }
            model.Name = product.Name;
            model.Price = product.Price;
            
            await _dbContext.SaveChangesAsync();

        }
        public async Task RemoveAsync(int productId)
        {
           var model = await _dbContext.Products.FirstOrDefaultAsync(p=>p.Id == productId);
            if (model == null)
            {
                throw new Exception($"Нет такого id - {productId}");
            }           
            _dbContext.Remove(model);
            await _dbContext.SaveChangesAsync();
        }
        public List<Product> GetAllProduct()
        {
            return _dbContext.Products.ToList();
        }
    }
}
