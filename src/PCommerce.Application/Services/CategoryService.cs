

using Microsoft.EntityFrameworkCore;
using PCommerce.Application.interfaces;
using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PCommerceDbContext _context;
        
        public CategoryService(PCommerceDbContext context) 
        { 
            _context = context; 
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categoryList = await _context.Categories.ToListAsync();

            var categoryDtoList = categoryList.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            
            return categoryDtoList;
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
        public async Task UpdateCategoryAsync(int id, CategoryDto updatedCategoryDto)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                throw new Exception();
            }
            category.Name = updatedCategoryDto.Name;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if(category==null)
            {
                throw new Exception();
            }

            _context.Remove(category);

            await _context.SaveChangesAsync();
        }
    }
}
