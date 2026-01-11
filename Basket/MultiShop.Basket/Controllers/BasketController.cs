using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.DTOs;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;
using System.Threading.Tasks;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var user = User.Claims;

            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDTO basketTotalDTO)
        {
            basketTotalDTO.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDTO);
            return Ok("Sepetteki değişiklikler kaydedildi!");
        }

        [HttpDelete]
        public IActionResult DeleteMyBasket()
        {
            _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepetiniz başarıyla silindi!");
        }

        [HttpPut]
        public IActionResult ClearMyBasket()
        {
            _basketService.ClearBasket(_loginService.GetUserId);
            return Ok("Sepetiniz başarıyla temizlendi!");
        }

        [HttpPut("ClearDiscountFromMyBasket")]
        public IActionResult ClearDiscountFromMyBasket()
        {
            _basketService.ClearDiscountFromBasket(_loginService.GetUserId);
            return Ok("Sepetinizdeki indirim başarıyla kaldırıldı!");
        }

        [HttpGet("GetItemCountInBasket")]
        public async Task<IActionResult> GetItemCountInBasket()
        {
            int count = await _basketService.GetItemCountInBasket(_loginService.GetUserId);
            return Ok(count);
        }
    }
}
