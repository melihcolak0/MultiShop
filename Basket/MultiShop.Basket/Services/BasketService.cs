using MultiShop.Basket.DTOs;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDTO> GetBasket(string userId)
        {
            var existingBasket = await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<BasketTotalDTO>(existingBasket);
        }

        public async Task SaveBasket(BasketTotalDTO basketTotalDTO)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDTO.UserId, JsonSerializer.Serialize(basketTotalDTO));
        }

        public async Task ClearBasket(string userId)
        {
            var basket = await GetBasket(userId);

            if (basket == null)
                return;

            basket.BasketItems.Clear();           

            await SaveBasket(basket);
        }

        public async Task ClearDiscountFromBasket(string userId)
        {
            var basket = await GetBasket(userId);

            if (basket == null)
                return;

            basket.DiscountCode = null;
            basket.DiscountRate = null;

            await SaveBasket(basket);
        }

        public async Task<int> GetItemCountInBasket(string userId)
        {
            var basket = await GetBasket(userId);

            if (basket == null)
                return 0;

            return basket.BasketItems.Count();            
        }
    }
}
