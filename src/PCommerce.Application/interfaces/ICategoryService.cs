

using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Application.interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryDto>> GetAllCategoriesAsync();
        public Task AddCategoryAsync(CategoryDto categoryDto);       
        public Task UpdateCategoryAsync(int id, CategoryDto updatedCategoryDto);
        public Task DeleteCategoryAsync(int id);
        
    }
}
