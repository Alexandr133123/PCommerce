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
        public async Task<IActionResult> AddProductAsync(ProductDto product)
        {
            var result = await _productService.AddProductAsync(product);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Product was added");
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var result = await _productService.GetProductsAsync();

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
        public async Task<IActionResult> UpdateProductAsync(int id, Product updatedProduct)
        {
            var result = await _productService.UpdateProductAsync(id, updatedProduct);

            if (result.IsFaulted)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok("Product was updated");
        }
    }
}
