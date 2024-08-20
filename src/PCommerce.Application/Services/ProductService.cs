using Microsoft.EntityFrameworkCore;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly PCommerceDbContext _dbContext;
        public ProductService(PCommerceDbContext productService)
        {
            _dbContext = productService;
        }
        public async Task AddAsync(ProductDto productDto)
        {
            var product = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Price = productDto.Price,
            };
            var categoryId = productDto.Categories.Select(p => p.Id).ToList();
            if (categoryId.Count > 0)
            {
                var categories = await _dbContext.Categories
                    .Where(c => categoryId.Contains(c.Id))
                    .ToListAsync();
                product.Categories = categories;
            }
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

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
            var model = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
            if (model == null)
            {
                throw new Exception($"Нет такого id - {productId}");
            }
            _dbContext.Remove(model);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<ProductDto>> GetAllProductAsync()
        {
            return await _dbContext.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Categories = p.Categories.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList(),
            }).ToListAsync();
        }
    }
}
