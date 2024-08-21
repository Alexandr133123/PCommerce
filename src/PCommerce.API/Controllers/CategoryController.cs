using Microsoft.AspNetCore.Mvc;
using PCommerce.Application.interfaces;
using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CategoryDto categoryDto)
        {
            await _categoryService.AddCategoryAsync(categoryDto);
            return Ok("Category was added");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories =  await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(int id, CategoryDto updatedCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(id, updatedCategoryDto);
            return Ok("Category was updated");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Category delete");
        }
    }
}
