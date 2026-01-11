namespace MultiShop.Catalog.DTOs.ProductDTOs
{
    public class ResultProductByFilterDTO
    {
        public string? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? SearchText { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public string ViewMode { get; set; }

        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Sort { get; set; }
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; }  
        public int PageNumber { get; set; } 
        public int PageSize { get; set; }  
        public int TotalCount { get; set; } 
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
