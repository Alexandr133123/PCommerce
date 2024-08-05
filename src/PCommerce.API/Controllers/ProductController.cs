using Microsoft.AspNetCore.Mvc;
using PCommerce.Application.Interfaces;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController
    {
        private readonly IProductService _productService;

        [HttpPost]
        public void AddProduct(Product product)
        {
            _productService.AddProduct(product);
        }
        [HttpGet]
        public List<Product> GetProducts()
        {
            return _productService.GetProducts();
        }
    }
}
