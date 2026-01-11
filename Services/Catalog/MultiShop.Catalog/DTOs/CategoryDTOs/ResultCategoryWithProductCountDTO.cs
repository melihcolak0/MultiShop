namespace MultiShop.Catalog.DTOs.CategoryDTOs
{
    public class ResultCategoryWithProductCountDTO
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImageUrl { get; set; }
        public int ProductCount { get; set; }
    }
}
