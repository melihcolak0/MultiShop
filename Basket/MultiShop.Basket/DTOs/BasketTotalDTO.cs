namespace MultiShop.Basket.DTOs
{
    public class BasketTotalDTO
    {
        //public string UserId { get; set; }
        //public string DiscountCode { get; set; }
        //public decimal? DiscountRate { get; set; }
        //public List<BasketItemDTO> BasketItems { get; set; }
        //public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }

        public string UserId { get; set; }
        public string? DiscountCode { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal ShippingPrice { get; set; } = 100;
        public List<BasketItemDTO> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.Price * x.Quantity); }
        public bool HasDiscount => DiscountRate.HasValue && DiscountRate > 0;
        public decimal DiscountAmount => TotalPrice * (DiscountRate ?? 0) / 100;
        public decimal GrandTotal => TotalPrice - DiscountAmount + ShippingPrice;
    }
}
