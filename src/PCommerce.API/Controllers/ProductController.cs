using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;


        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> GetAllProductsAsync(string? category, [FromQuery] ProductFilters? productFilters)
        {

            var products = await _productService.GetAllProductsAsync(category,productFilters);

            if (products.IsFaulted)
            {
                return BadRequest(products.ErrorMessage);
            }
            return Ok(products.ResultValue);

        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(ProductDto product)
        {
            var result = await _productService.AddProductAsync(product);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok("Product added");
        }
        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync(ProductDto productToUpdate)
        {
            var result = await _productService.UpdateProductAsync(productToUpdate);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Product Updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveProductAsync(int id)
        {
            var result = await _productService.RemoveProductAsync(id);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Product Deleted");
        }
        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProductByIdAsync(int productId)
        {
            var product =  await _productService.GetProductByIdAsync(productId);

            if (product.IsFaulted)
            {
                return BadRequest($"Product with Id{productId} not found");
            }

            return Ok(product.ResultValue);
        }

    }
}
