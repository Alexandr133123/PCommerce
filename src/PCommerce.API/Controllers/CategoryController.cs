using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;

namespace PCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CategoryDto categoryDto)
        {
            await _categoryService.AddCategoryAsync(categoryDto);
            return Ok("Category Added");
        }
        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryDto categoryDto)
        {
            await _categoryService.UpdateCategoryAsync(categoryDto);
            return Ok("Product updated");

        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategoryAsync(int id)
        {
            await _categoryService.RemoveCategoryAsync(id);
            return Ok("Category Deleted");
        }
    }
}
