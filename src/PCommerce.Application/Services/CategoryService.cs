﻿using Microsoft.EntityFrameworkCore;
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
        public CategoryService(PCommerceDbContext context,ValidateService validateService)
        {
            _context = context;
            _validateService = validateService;
        }

        public async Task<OperationResult<IEnumerable<CategoryDto>>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            var categoryDto = categories.Select(p => new CategoryDto
            {
                Id = p.Id,

                Name = p.Name,

            }).ToList();
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

            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();

            return OperationResult.Success();

            
        }
        public async Task<OperationResult> UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == categoryDto.Id);

            var validateResult = await _validateService.ValidateAsync(existingCategory);

            if (!validateResult.IsValid)
            {
                var errorMessage = string.Join("\n", validateResult.Errors.Select(p => p.ErrorMessage));

                return OperationResult.Failure(errorMessage);
            }

            if (existingCategory == null)
            {
                throw new Exception($"Category with id{existingCategory.Id} did not exist");
            }

            existingCategory.Name = categoryDto.Name;

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
