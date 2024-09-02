using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;


namespace PCommerce.Application.Interfaces
{
    public interface IProductService
    {
        public Task<List<ProductDto>> GetProductsAsync();
        public Task<OperationResult> AddProductAsync(ProductDto product);
        public Task DeleteProductAsync(int id);
        public Task UpdateProductAsync(int id, Product updatedProduct);
    }
}
