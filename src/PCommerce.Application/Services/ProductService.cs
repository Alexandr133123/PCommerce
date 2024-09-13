using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;
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

        private readonly ValidateService _validateService;

        private readonly IMapper _mapper;

        public ProductService(PCommerceDbContext context, ValidateService validateService, IMapper mapper)
        {
            _context = context;
            _validateService = validateService;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<ProductDto>>> GetAllProductsAsync()
        {
            var products = await _context.Products.Include(p => p.Categories).ToListAsync();

            var productsDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return OperationResult<IEnumerable<ProductDto>>.Success(productsDtos);

        }

        public async Task<OperationResult> AddProductAsync(ProductDto productDto)
        {
            var validateResult = await _validateService.ValidateAsync(productDto);

            if (!validateResult.IsValid)
            {
                string responseMessage = string.Join("\n", validateResult.Errors.Select(p => p.ErrorMessage));

                return OperationResult.Failure(responseMessage);

            }

            var product = _mapper.Map<Product>(productDto);

            List<int> categoryIds = productDto.Categories.Select(c => c.Id).ToList();


            if (categoryIds.Any())
            {
                var categories = await _context.Categories.Where(c => categoryIds.Contains(c.Id)).ToListAsync();

                product.Categories = categories;
            }
            await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return OperationResult.Success();

        }

        public async Task<OperationResult> UpdateProductAsync(ProductDto productToUpdate)
        {

            var validateResult = await _validateService.ValidateAsync(productToUpdate);

            if (!validateResult.IsValid)
            {
                string responseMessage = string.Join("\n", validateResult.Errors.Select(p => p.ErrorMessage));

                return OperationResult.Failure(responseMessage);
            }

            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == productToUpdate.Id);


            if (existingProduct == null)
            {
                return OperationResult.Failure($"Product with ID {productToUpdate.Id} not found");
            }

            existingProduct.Name = productToUpdate.Name;

            existingProduct.Price = productToUpdate.Price;

            await _context.SaveChangesAsync();

            return OperationResult.Success();

        }

        public async Task<OperationResult> RemoveProductAsync(int id)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (existingProduct == null)
            {
                return OperationResult.Failure($"Product with ID {id} not found");
            }

            _context.Remove(existingProduct);

            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }
        public async Task<OperationResult<ProductDto>> GetProductByIdAsync(int productDtoId)
        {
            var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == productDtoId);

            if (product == null)
            {
                OperationResult<ProductDto>.Failure($"Product with ID {productDtoId} not found");
            }

            var productDto = _mapper.Map<ProductDto>(product);

            return OperationResult<ProductDto>.Success(productDto);
        }
    }
}
