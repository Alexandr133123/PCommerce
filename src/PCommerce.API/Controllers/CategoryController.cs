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
            var result = await _categoryService.AddCategoryAsync(categoryDto);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Category was added");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var result =  await _categoryService.GetAllCategoriesAsync();

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.ResultValue);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCategoryAsync(int id, CategoryDto updatedCategoryDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, updatedCategoryDto);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Category was updated");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Category delete");
        }
    }
}
