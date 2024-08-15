using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public void Add(Product product)
        {
            _productService.Add(product);
        }
        [HttpGet]
        public List<Product> GetAllProduct()
        {
            return _productService.GetAllProduct();
        }
        [HttpPut]
        public async Task UpdateAsync(Product product, int productId)
        {
             await _productService.UpdateAsync(product, productId);

        }
        [HttpDelete]
        public async Task RemoveAsync(int productId)
        {
            await _productService.RemoveAsync(productId);

        }

    }
}
