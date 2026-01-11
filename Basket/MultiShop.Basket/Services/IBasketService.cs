using MultiShop.Basket.DTOs;

namespace MultiShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDTO> GetBasket(string userId);
        Task SaveBasket(BasketTotalDTO basketTotalDTO);
        Task DeleteBasket(string userId);
        Task ClearBasket(string userId);
        Task ClearDiscountFromBasket(string userId);
        Task<int> GetItemCountInBasket(string userId);
    }
}
