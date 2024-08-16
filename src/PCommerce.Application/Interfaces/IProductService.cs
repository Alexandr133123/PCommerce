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
        Task<IEnumerable <ProductDto>> GetAllProductsAsync();

        Task AddProductAsync(Product product);

        Task UpdateProductAsync(Product product);

        Task RemoveProductAsync(int id);
    }
}
