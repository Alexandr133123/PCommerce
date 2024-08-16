using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PCommerce.Application.Interfaces;
using PCommerce.Infrastructure.Data.Models;

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
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            await _productService.AddProductAsync(product);
            return Ok("Product was added");
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            await _productService.DeleteProduct(product);
            return Ok("Product was deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(int id, Product updatedProduct)
        {
            await _productService.UpdateProduct(id, updatedProduct);
            return Ok("Product was updated");
        }

    }
}
