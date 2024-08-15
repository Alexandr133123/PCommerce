using PCommerce.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Interfaces
{
    public interface IProductService 
    {
        void Add (Product product);
        void Remove (Product product, int productId);
        void Update (Product product, int productId);
        List <Product> GetAllProduct();
        
    }
}
