using Microsoft.EntityFrameworkCore;
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

        public async Task<OperationResult<List<ProductDto>>> GetProductsAsync()
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

            return OperationResult<List<ProductDto>>.Success(productDtoList);
        }
        public async Task<OperationResult> AddProductAsync(ProductDto product)
        {
            var validate = await _validationService.ValidateAsync(product);

            if (validate.IsFaulted)
            {
                return OperationResult.Failure(validate.ErrorMessage);
            }

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

            return OperationResult.Success();
        }
        public async Task<OperationResult> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                OperationResult.Failure($"Product with id - {id}, not found");
            }
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return OperationResult.Success();
        }
        public async Task<OperationResult> UpdateProductAsync(int id, Product updatedProduct)
        {
            var validate = await _validationService.ValidateAsync(updatedProduct);

            if (validate.IsFaulted)
            {
                return OperationResult.Failure(validate.ErrorMessage);
            }

            var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);
            if (product == null)
            {
                OperationResult.Failure($"Product with id - {id}, not found");
            }
            product.Price = updatedProduct.Price;
            product.Name = updatedProduct.Name;
            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
