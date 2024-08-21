using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        Task AddAsync(CategoryDto categoryDto);
        Task RemoveAsync(int categoryId);
        Task UpdateAsync(CategoryDto categoryDto);
        Task<List<CategoryDto>> GetAllCategoryAsync();

    }
}
