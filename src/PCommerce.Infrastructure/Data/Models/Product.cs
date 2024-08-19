namespace PCommerce.Infrastructure.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<Category> Categories { get; set; }
    }
}
