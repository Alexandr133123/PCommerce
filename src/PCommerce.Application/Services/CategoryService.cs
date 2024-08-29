using Microsoft.EntityFrameworkCore;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly PCommerceDbContext _dbContext;
        public CategoryService(PCommerceDbContext categoryService)
        {
            _dbContext = categoryService;
        }
        public async Task AddAsync(CategoryDto categoryDto)
        {
            var category = new Category()
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
            };
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(CategoryDto categoryDto)
        {
            var model = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == categoryDto.Id);
            if (model == null)
            {
                throw new Exception($"Нет такого id - {categoryDto.Id}");
            }
            model.Name = categoryDto.Name;
            await _dbContext.SaveChangesAsync();

        }
        public async Task RemoveAsync(int categoryId)
        {
            var model = await _dbContext.Categories.FirstOrDefaultAsync(p => p.Id == categoryId);
            if (model == null)
            {
                throw new Exception($"Нет такого id - {categoryId}");
            }
            _dbContext.Remove(model);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<List<CategoryDto>> GetAllCategoryAsync()
        {
            return await _dbContext.Categories.Select(p => new CategoryDto
            {
                Id = p.Id,
                Name = p.Name,
            }).ToListAsync();
        }
    }
}
