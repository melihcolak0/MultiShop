using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponent : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _NavbarUILayoutComponent(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int count = await _basketService.GetItemCountInBasket();
            return View(count);
        }
    }
}
