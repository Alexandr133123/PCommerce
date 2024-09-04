

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
        private readonly ValidationService _validationService;
        
        public CategoryService(PCommerceDbContext context, ValidationService validationService) 
        { 
            _context = context;
            _validationService = validationService;
        }

        public async Task<OperationResult<List<CategoryDto>>> GetAllCategoriesAsync()
        {

            var categoryList = await _context.Categories.ToListAsync();

            var categoryDtoList = categoryList.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            
            return OperationResult<List<CategoryDto>>.Success(categoryDtoList);
        }
        public async Task<OperationResult> AddCategoryAsync(CategoryDto categoryDto)
        {
            var validate = await _validationService.ValidateAsync(categoryDto);

            if (validate.IsFaulted)
            {
                return OperationResult.Failure(validate.ErrorMessage);
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
        public async Task<OperationResult> UpdateCategoryAsync(int id, CategoryDto updatedCategoryDto)
        {
            var validate = await _validationService.ValidateAsync(updatedCategoryDto);

            if (validate.IsFaulted)
            {
                return OperationResult.Failure(validate.ErrorMessage);
            }

            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category == null)
            {
                OperationResult.Failure($"Ctegory with id - {id} not found");
            }

            category.Name = updatedCategoryDto.Name;
            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }
        public async Task<OperationResult> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if(category==null)
            {
                OperationResult.Failure($"Category with id - {id} not found");
            }

            _context.Remove(category);

            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
