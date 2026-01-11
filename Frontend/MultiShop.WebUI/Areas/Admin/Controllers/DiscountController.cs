using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.DiscountDTOs;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly ICouponService _couponService;

        public DiscountController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _couponService.GetAllCouponAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateCouponDTO createCouponDTO)
        {
            createCouponDTO.IsActive = true;
            createCouponDTO.ValidDate = DateTime.Now.AddMonths(1);

            await _couponService.CreateCouponAsync(createCouponDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _couponService.DeleteCouponAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(int id)
        {
            var value = await _couponService.GetCouponByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateCouponDTO updateCouponDTO)
        {
            await _couponService.UpdateCouponAsync(updateCouponDTO);
            return RedirectToAction("Index");
        }
    }
}
