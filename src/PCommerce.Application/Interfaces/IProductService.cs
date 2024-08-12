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
        void Remove (Product product);
        void Update (Product product);
        List <Product> GetAllProduct();
    }
}
