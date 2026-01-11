using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.BasketDTOs;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()        
        {
            var basket = await _basketService.GetBasketAsync();
            return View(basket);
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            var item = new BasketItemDTO
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductImageUrl = product.ProductImageUrl,
                Price = product.ProductPrice,
                Quantity = 1
            };

            await _basketService.AddBasketItemAsync(item);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItemAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearBasket()
        {
            await _basketService.ClearBasketAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ClearDiscount()
        {
            await _basketService.ClearDiscountAsync();
            return RedirectToAction("Index");
        }
               
        public async Task<IActionResult> UpdateQuantity(string productId, int change)
        {
            await _basketService.UpdateQuantityAsync(productId, change);
            return RedirectToAction("Index");
        }
    }
}
