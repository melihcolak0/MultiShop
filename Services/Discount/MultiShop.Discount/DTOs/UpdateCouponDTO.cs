namespace MultiShop.Discount.DTOs
{
    public class UpdateCouponDTO
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
        public DateTime ValidDate { get; set; }
    }
}
