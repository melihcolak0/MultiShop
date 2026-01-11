using MultiShop.DTOLayer.BasketDTOs;
using NuGet.ContentModel;
using System.Net.Http;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItemAsync(BasketItemDTO basketItemDTO)
        {
            var basket = await GetBasketAsync();

            if (basket == null)
            {
                basket = new BasketTotalDTO
                {
                    BasketItems = new List<BasketItemDTO>()
                };
            }

            var existingItem = basket.BasketItems
                .FirstOrDefault(x => x.ProductId == basketItemDTO.ProductId);

            if (existingItem == null)
            {
                // Ürün yoksa yeni ekle
                basket.BasketItems.Add(basketItemDTO);
            }
            else
            {
                // Ürün varsa quantity artır
                existingItem.Quantity += basketItemDTO.Quantity > 0
                    ? basketItemDTO.Quantity
                    : 1;
            }

            await SaveBasketAsync(basket);

            // Eski kod parçası:

            //var basket = await GetBasketAsync();

            //if(basket != null)
            //{
            //    if(!basket.BasketItems.Any(x => x.ProductId == basketItemDTO.ProductId))
            //    {
            //        basket.BasketItems.Add(basketItemDTO);
            //    }
            //    else
            //    {
            //        basket = new BasketTotalDTO();
            //        basket.BasketItems.Add(basketItemDTO);
            //    }
            //}

            //await SaveBasketAsync(basket);
        }

        public async Task ApplyDiscountAsync(string couponCode, decimal discountRate)
        {
            var basket = await GetBasketAsync();

            basket.DiscountCode = couponCode;
            basket.DiscountRate = discountRate;

            await SaveBasketAsync(basket);
        }

        public async Task ClearBasketAsync()
        {
            var response = await _httpClient.PutAsync("basket", null);           
            response.EnsureSuccessStatusCode();
        }

        public async Task ClearDiscountAsync()
        {
            var response = await _httpClient.PutAsync($"basket/ClearDiscountFromMyBasket", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteBasketAsync()
        {
            var response = await _httpClient.DeleteAsync("basket");
            response.EnsureSuccessStatusCode();
        }

        public async Task<BasketTotalDTO> GetBasketAsync()
        {
            return await _httpClient.GetFromJsonAsync<BasketTotalDTO>("basket");
        }

        public async Task<int> GetItemCountInBasket()
        {
            return await _httpClient.GetFromJsonAsync<int>("basket/GetItemCountInBasket");
        }

        public async Task<bool> RemoveBasketItemAsync(string productId)
        {
            var basket = await GetBasketAsync();

            if (basket != null)
            {
                var deletedItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);

                if (deletedItem != null)
                {
                    var result = basket.BasketItems.Remove(deletedItem);

                    await SaveBasketAsync(basket);
                    return true;
                }
            }

            return false;
        }

        public async Task SaveBasketAsync(BasketTotalDTO basketTotalDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("basket", basketTotalDTO);            
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateQuantityAsync(string productId, int change)
        {
            var basket = await GetBasketAsync();
            if (basket == null) return;

            var item = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            if (item == null) return;

            item.Quantity += change;

            if (item.Quantity <= 0)
            {
                basket.BasketItems.Remove(item);
            }

            await SaveBasketAsync(basket);
        }
    }
}

// İkinci Çözüm Yolu:

//private readonly HttpClient _httpClient;

//public BasketService(HttpClient httpClient)
//{
//    _httpClient = httpClient;
//}

//public async Task AddBasketItemAsync(BasketItemDTO basketItemDTO)
//{
//    var basket = await GetBasketAsync() ?? new BasketTotalDTO();

//    var item = basket.BasketItems
//        .FirstOrDefault(x => x.ProductId == basketItemDTO.ProductId);

//    if (item == null)
//    {
//        basket.BasketItems.Add(basketItemDTO);
//    }
//    else
//    {
//        item.Quantity += basketItemDTO.Quantity;
//    }

//    await SaveBasketAsync(basket);
//}

//public async Task<BasketTotalDTO> GetBasketAsync()
//{
//    return await _httpClient.GetFromJsonAsync<BasketTotalDTO>("basket");
//}

//public async Task SaveBasketAsync(BasketTotalDTO basketTotalDTO)
//{
//    var response = await _httpClient.PostAsJsonAsync("basket", basketTotalDTO);
//    response.EnsureSuccessStatusCode();
//}

//public async Task ClearBasketAsync()
//{
//    var response = await _httpClient.PutAsync("basket", null);
//    response.EnsureSuccessStatusCode();
//}

//public async Task DeleteBasketAsync()
//{
//    var response = await _httpClient.DeleteAsync("basket");
//    response.EnsureSuccessStatusCode();
//}

//public async Task<bool> RemoveBasketItemAsync(string productId)
//{
//    var basket = await GetBasketAsync();
//    if (basket == null) return false;

//    var item = basket.BasketItems.FirstOrDefault(x => x.ProductId == productId);
//    if (item == null) return false;

//    basket.BasketItems.Remove(item);
//    await SaveBasketAsync(basket);
//    return true;
//}