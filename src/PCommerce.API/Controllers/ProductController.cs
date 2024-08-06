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
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
    }
}
