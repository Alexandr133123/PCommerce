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
        public List<Product> GetProducts();
        public void AddProduct(Product product);
    }
}
