using PCommerce.Application.Models;



namespace PCommerce.Application.Interfaces
{
    public interface IProductService
    {
        public Task<OperationResult<List<ProductDto>>> GetProductsAsync(string? category, ProductFilters? productFilters);
        public Task<OperationResult> AddProductAsync(ProductDto productDto);
        public Task<OperationResult> DeleteProductAsync(int id);
        public Task<OperationResult> UpdateProductAsync(int id, ProductDto updatedProductDto);
        public Task<OperationResult<ProductDto>> GetProductByIdAsync(int productId);
    }
}
