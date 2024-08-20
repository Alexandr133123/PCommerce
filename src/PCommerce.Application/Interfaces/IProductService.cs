using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;

namespace PCommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(ProductDto productDto);
        Task RemoveAsync(int productId);
        Task UpdateAsync(Product product, int productId);
        Task<List<ProductDto>> GetAllProductAsync();
       
    }
}
