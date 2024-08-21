using PCommerce.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();

        Task AddCategoryAsync (CategoryDto categoryDto);

        Task RemoveCategoryAsync(int id);

        Task UpdateCategoryAsync (CategoryDto categoryDto);

        


    }
}
