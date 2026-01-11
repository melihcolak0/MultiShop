using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Models
{
    public class CategoryWithProducts : Category
    {
        public List<Product> Products { get; set; }
    }
}
