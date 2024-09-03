using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;


namespace PCommerce.Application.Interfaces
{
    public interface IProductService
    {
        public Task<OperationResult<List<ProductDto>>> GetProductsAsync();
        public Task<OperationResult> AddProductAsync(ProductDto product);
        public Task<OperationResult> DeleteProductAsync(int id);
        public Task<OperationResult> UpdateProductAsync(int id, Product updatedProduct);
    }
}
