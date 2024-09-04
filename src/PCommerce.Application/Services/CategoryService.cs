

using AutoMapper;
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
        private readonly IMapper _mapper;
        
        public CategoryService(PCommerceDbContext context, ValidationService validationService, IMapper mapper) 
        { 
            _context = context;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<CategoryDto>>> GetAllCategoriesAsync()
        {
            var categoryList = await _context.Categories.ToListAsync();

            var mapCategoryList = _mapper.Map<List<CategoryDto>>(categoryList);
            
            return OperationResult<List<CategoryDto>>.Success(mapCategoryList);
        }
        public async Task<OperationResult> AddCategoryAsync(CategoryDto categoryDto)
        {
            var validate = await _validationService.ValidateAsync(categoryDto);

            if (validate.IsFaulted)
            {
                return OperationResult.Failure(validate.ErrorMessage);
            }

            var mapCategory = _mapper.Map<Category>(categoryDto); 

            await _context.AddAsync(mapCategory);

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
                return OperationResult.Failure($"Ctegory with id - {id} not found");
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
                return OperationResult.Failure($"Category with id - {id} not found");
            }

            _context.Remove(category);

            await _context.SaveChangesAsync();

            return OperationResult.Success();
        }
    }
}
