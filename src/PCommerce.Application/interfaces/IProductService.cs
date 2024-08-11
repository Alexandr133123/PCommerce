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
        public Task<List<Product>> GetProductsAsync();
        public Task AddProductAsync(Product product);
        public Task DeleteProduct(Product product);
        public Task UpdateProduct(int id, Product updatedProduct);
    }
}
