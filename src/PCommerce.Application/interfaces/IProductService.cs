using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;


namespace PCommerce.Application.Interfaces
{
    public interface IProductService
    {
        public Task<OperationResult<List<ProductDto>>> GetProductsAsync();
        public Task<OperationResult> AddProductAsync(ProductDto productDto);
        public Task<OperationResult> DeleteProductAsync(int id);
        public Task<OperationResult> UpdateProductAsync(int id, ProductDto updatedProductDto);
    }
}
