using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCommerce.Infrastructure.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category? ParentCategory;
        public int? ParentCategoryId;
        public List<Category>? ChildCategories;
        public List<Product>? Products { get; set; }
    }
}
