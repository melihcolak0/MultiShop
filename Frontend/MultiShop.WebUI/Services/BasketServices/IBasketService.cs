using MultiShop.DTOLayer.BasketDTOs;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasketAsync();
        Task SaveBasketAsync(BasketTotalDTO basketTotalDTO);
        Task DeleteBasketAsync();
        Task ClearBasketAsync();
        Task AddBasketItemAsync(BasketItemDTO basketItemDTO);
        Task<bool> RemoveBasketItemAsync(string productId);
        Task ApplyDiscountAsync(string couponCode, decimal discountRate);
        Task ClearDiscountAsync();
        Task UpdateQuantityAsync(string productId, int change);
        Task<int> GetItemCountInBasket();
    }
}
