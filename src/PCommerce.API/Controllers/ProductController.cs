using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCommerce.Application.Interfaces;
using PCommerce.Application.Models;
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
        public IActionResult AddAsync(ProductDto productDto)
        {
            _productService.AddAsync(productDto);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductAsync()
        {            
            return Ok(await _productService.GetAllProductAsync());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Product product, int productId)
        {
            await _productService.UpdateAsync(product, productId);
            return Ok(); 
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAsync(int productId)
        {
            await _productService.RemoveAsync(productId);
            return Ok();
        }

    }
}
