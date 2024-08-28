using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly PCommerceDbContext _context;
        private readonly ValidationService _validationService;
        public ProductService(PCommerceDbContext context, ValidationService validationService)
        {
            _context = context;
            _validationService = validationService;
        }

        public async Task<List<ProductDto>> GetProductsAsync()
        {

            var productList = await _context.Products.Include(c => c.Categories).ToListAsync();

            var productDtoList = productList.Select(p => new ProductDto
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

            return productDtoList;
        }
        public async Task AddProductAsync(ProductDto product)
        {
            await _validationService.ValidateAsync(product);

            var prod = new Product()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            var categoryId = product.Categories.Select(p => p.Id).ToList();
            if (categoryId.Count != 0)
            {
                var categoryes = await _context.Categories
                    .Where(c => categoryId.Contains(c.Id))
                    .ToListAsync();

                prod.Categories = categoryes;
            }

            await _context.AddAsync(prod);

            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if(product == null)
            {
                throw new Exception();
            }
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProductAsync(int id, Product updatedProduct)
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
