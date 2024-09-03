using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<OperationResult<IEnumerable<ProductDto>>> GetAllProductsAsync();

        Task <OperationResult> AddProductAsync(ProductDto productDto);

        Task<OperationResult>UpdateProductAsync(Product product);

        Task<OperationResult> RemoveProductAsync(int id);
    }
}
