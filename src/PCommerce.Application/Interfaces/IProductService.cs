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
        Task<IEnumerable <Product>> GetAllProductsAsync();

        Task AddProductAsync(Product product);

        Task UpdateProductAsync(int id,Product product);

        Task RemoveProductAsync(int id);
    }
}
