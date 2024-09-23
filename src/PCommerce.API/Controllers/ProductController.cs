using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PCommerce.Application.Interfaces;
using PCommerce.Infrastructure.Data.Models;
using PCommerce.Application.Models;

namespace PCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductDto productDto)
        {
            var result = await _productService.AddProductAsync(productDto);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Product was added");
        }
        [HttpGet("{category}")]
        public async Task<IActionResult> GetProductsAsync(string? category, [FromQuery] ProductFilters? productFilters)
        {
            var result = await _productService.GetProductsAsync(category, productFilters);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.ResultValue);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }
            
            return Ok("Product was deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(int id, ProductDto updatedProductDto)
        {
            var result = await _productService.UpdateProductAsync(id, updatedProductDto);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Product was updated");
        }
        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            var result = await _productService.GetProductByIdAsync(productId);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok(result.ResultValue);
        }
    }
}
