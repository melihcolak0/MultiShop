using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly ICouponService _couponService;

        public DiscountController(ICouponService couponService, IBasketService basketService)
        {
            _couponService = couponService;
            _basketService = basketService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Apply(string couponCode)
        {
            var coupon = await _couponService.GetCouponByCode(couponCode);

            if (coupon == null || !coupon.IsActive || coupon.ValidDate < DateTime.Now)
            {
                TempData["CouponError"] = "Kupon kodu geçersiz!";
                return RedirectToAction("Index", "ShoppingCart");
            }

            await _basketService.ApplyDiscountAsync(
                coupon.CouponCode,
                coupon.Rate
            );

            await _couponService.InActivateCouponByCodeAsync(couponCode);

            TempData["CouponSuccess"] = $"\"{coupon.CouponCode}\" kodu ile %{coupon.Rate} indirim uygulandı!";

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
