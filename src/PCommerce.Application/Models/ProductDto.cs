

namespace PCommerce.Application.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<CategoryDto> Categories { get; set; }
    }
}
