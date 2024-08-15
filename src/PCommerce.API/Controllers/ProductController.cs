using Microsoft.AspNetCore.Mvc;
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
        
         
    }
}
