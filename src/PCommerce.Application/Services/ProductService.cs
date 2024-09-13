using AutoMapper;
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
        private readonly IMapper _mapper;
        public ProductService(PCommerceDbContext context, ValidationService validationService, IMapper mapper)
        {
            _context = context;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<ProductDto>>> GetProductsAsync()
        {
            var productList = await _context.Products.Include(c => c.Categories).ToListAsync();

            var mapProductList = _mapper.Map<List<ProductDto>>(productList);

            return OperationResult<List<ProductDto>>.Success(mapProductList);
        }
        public async Task<OperationResult> AddProductAsync(ProductDto productDto)
        {
            var validate = await _validationService.ValidateAsync(productDto);

            if (validate.IsFaulted)
            {
                return OperationResult.Failure(validate.ErrorMessage);
            }

            var mapProduct = _mapper.Map<Product>(productDto);

            var categoryId = productDto.Categories.Select(p => p.Id).ToList();
            if (categoryId.Count != 0)
            {
                var categories = await _context.Categories
                    .Where(c => categoryId.Contains(c.Id))
                    .ToListAsync();
                mapProduct.Categories = categories;
            }

            await _context.AddAsync(mapProduct);

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
        public async Task<OperationResult> UpdateProductAsync(int id, ProductDto updatedProductDto)
        {
            var validate = await _validationService.ValidateAsync(updatedProductDto);

            if (validate.IsFaulted)
            {
                return OperationResult.Failure(validate.ErrorMessage);
            }

            var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == id);

            if (product == null)
            {
                OperationResult.Failure($"Product with id - {id}, not found");
            }

            product.Price = updatedProductDto.Price;
            product.Name = updatedProductDto.Name;

            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }

        public async Task<OperationResult<ProductDto>> GetProductByIdAsync(int productId)
        {
            var product = await _context.Products.Include(c => c.Categories).FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null)
            {
                return OperationResult<ProductDto>.Failure($"Product with id - {productId}, not found");
            }

            var mapProduct = _mapper.Map<ProductDto>(product);

            return OperationResult<ProductDto>.Success(mapProduct);
        }
    }
}
