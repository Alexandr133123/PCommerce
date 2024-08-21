using Microsoft.AspNetCore.Mvc;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;
using PCommerce.Application.Services;
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
        public IActionResult AddAsync(CategoryDto categoryDto)
        {
            _categoryService.AddAsync(categoryDto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            return Ok(await _categoryService.GetAllCategoryAsync());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CategoryDto categoryDto)
        {
            await _categoryService.UpdateAsync(categoryDto);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(int categoryId)
        {
            await _categoryService.RemoveAsync(categoryId);
            return Ok();
        }
    }
}
