using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.DTOs;
using MultiShop.Discount.Entities;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [AllowAnonymous] // authorize yapılacak
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;

        public CouponsController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCouponsList()
        {
            var values = await _couponService.GetAllCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCouponById(string id)
        {
            var value = await _couponService.GetCouponByIdAsync(id);
            return Ok(value);
        }

        [HttpGet("GetCouponByCode")]
        public async Task<IActionResult> GetCouponByCode(string code)
        {
            var value = await _couponService.GetCouponByCodeAsync(code);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDTO createCouponDTO)
        {
            await _couponService.CreateCouponAsync(createCouponDTO);
            return Ok("Yeni kupon başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon(string id)
        {
            await _couponService.DeleteCouponAsync(id);
            return Ok("Kupon başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDTO updateCouponDTO)
        {
            await _couponService.UpdateCouponAsync(updateCouponDTO);
            return Ok("Kupon başarıyla güncellendi!");
        }

        [HttpPut("InActivateCouponAsync")]
        public async Task<IActionResult> InActivateCouponAsync(string code)
        {
            await _couponService.InActivateCouponByCodeAsync(code);
            return Ok("Kupon başarıyla inaktif edildi!");
        }

        [HttpGet("GetCoupunCount")]
        public async Task<IActionResult> GetCoupunCount()
        {
            var value = await _couponService.GetCouponCount();
            return Ok(value);
        }
    }
}
