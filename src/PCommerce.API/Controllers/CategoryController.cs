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

            if (categories.IsFaulted)
            {
                return BadRequest(categories.ErrorMessage);
            }

            return Ok(categories.ResultValue);
        }
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(CategoryDto categoryDto)
        {
            var result = await _categoryService.AddCategoryAsync(categoryDto);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Category Added");
        }
        [HttpPost("UpdateCategory")]
        public async Task<IActionResult> UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(categoryDto);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Category updated");

        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategoryAsync(int id)
        {
            var result = await _categoryService.RemoveCategoryAsync(id);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Category Deleted");
        }
    }
}
