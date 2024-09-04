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
        Task<OperationResult<IEnumerable<CategoryDto>>> GetAllCategoriesAsync();

        Task<OperationResult> AddCategoryAsync (CategoryDto categoryDto);

        Task <OperationResult> RemoveCategoryAsync(int id);

        Task<OperationResult> UpdateCategoryAsync (CategoryDto categoryDto);

        


    }
}
