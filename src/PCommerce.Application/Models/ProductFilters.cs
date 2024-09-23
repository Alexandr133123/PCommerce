using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.Models
{
    public class ProductFilters
    {
        public decimal? PriceFrom {  get; set; }

        public decimal? PriceTo { get; set; }

        public string? Name { get; set; }
    }
}
