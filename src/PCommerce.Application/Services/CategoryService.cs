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
    public class CategoryService:ICategoryService
    {
        private readonly PCommerceDbContext _context;

        private readonly ValidateService _validateService;

        private readonly IMapper _mapper;
        public CategoryService(PCommerceDbContext context,ValidateService validateService,IMapper mapper)
        {
            _context = context;
            _validateService = validateService;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return OperationResult<IEnumerable<CategoryDto>>.Success(categoryDto);
        }
        public async Task<OperationResult>AddCategoryAsync(CategoryDto categoryDto)
        {
            var validateResult = await _validateService.ValidateAsync(categoryDto);

            if (!validateResult.IsValid)
            {
                var errorMessage = string.Join("\n", validateResult.Errors.Select(p => p.ErrorMessage));

                return OperationResult.Failure(errorMessage);
            }

            var category = _mapper.Map<Category>(categoryDto);

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();

            return OperationResult.Success();

            
        }
        public async Task<OperationResult> UpdateCategoryAsync(CategoryDto categoryToUpdate)
        {
            var validateResult = await _validateService.ValidateAsync(categoryToUpdate);

            if (!validateResult.IsValid)
            {
                var errorMessage = string.Join("\n", validateResult.Errors.Select(p => p.ErrorMessage));

                return OperationResult.Failure(errorMessage);
            }

            var existingCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == categoryToUpdate.Id);

            if (existingCategory == null)
            {
                throw new Exception($"Category with id{existingCategory.Id} did not exist");
            }

            existingCategory.Name = categoryToUpdate.Name;

            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }
        public async Task<OperationResult> RemoveCategoryAsync(int id)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

            if (existingCategory == null)
            {
                throw new Exception($"Product with ID {id} not found");
            }

            _context.Remove(existingCategory);

            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
