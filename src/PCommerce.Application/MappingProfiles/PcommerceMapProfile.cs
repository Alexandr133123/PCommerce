using AutoMapper;
using PCommerce.Application.Models;
using PCommerce.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Application.MappingProfiles
{
    public class PcommerceMapProfile:Profile
    {
        public PcommerceMapProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();

            CreateMap<Category,CategoryDto>().ReverseMap();
        }

    }
}
