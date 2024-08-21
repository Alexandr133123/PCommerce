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
        public CategoryService(PCommerceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _context.Categories.ToListAsync();

            var categoryDto = categories.Select(p => new CategoryDto
            {
                Id = p.Id,

                Name = p.Name,

            }).ToList();
            return categoryDto;
        }
        public async Task AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();
            
        }
        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == categoryDto.Id);

            if (existingCategory == null)
            {
                throw new Exception($"Category with id{existingCategory.Id} did not exist");
            }

            existingCategory.Name = categoryDto.Name;

            await _context.SaveChangesAsync();
        }
        public async Task RemoveCategoryAsync(int id)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);

            if (existingCategory == null)
            {
                throw new Exception($"Product with ID {id} not found");
            }

            _context.Remove(existingCategory);

            await _context.SaveChangesAsync();
        }
    }
}
