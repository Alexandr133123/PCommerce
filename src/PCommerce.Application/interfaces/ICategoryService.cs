

using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Application.interfaces
{
    public interface ICategoryService
    {
        public Task<OperationResult<List<CategoryDto>>> GetAllCategoriesAsync();
        public Task<OperationResult> AddCategoryAsync(CategoryDto categoryDto);       
        public Task<OperationResult> UpdateCategoryAsync(int id, CategoryDto updatedCategoryDto);
        public Task<OperationResult> DeleteCategoryAsync(int id);
        
    }
}
