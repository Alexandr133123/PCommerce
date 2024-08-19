using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;


namespace PCommerce.Application.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetProductsAsync();
        public Task AddProductAsync(ProductDto product);
        public Task DeleteProduct(Product product);
        public Task UpdateProduct(int id, Product updatedProduct);
    }
}
