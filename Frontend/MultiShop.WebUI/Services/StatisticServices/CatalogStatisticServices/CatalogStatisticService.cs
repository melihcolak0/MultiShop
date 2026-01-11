
using System.Globalization;

namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetCategoryCountAsync()
        {
            var httpResponse = await _httpClient.GetAsync("statistics/GetCategoryCount");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return long.Parse(rawContent.Trim());
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var httpResponse = await _httpClient.GetAsync("statistics/GetMaxPriceProductName");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return rawContent.Trim();
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var httpResponse = await _httpClient.GetAsync("statistics/GetMinPriceProductName");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return rawContent.Trim();
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var httpResponse = await _httpClient.GetAsync("statistics/GetProductAvgPrice");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return decimal.Parse(rawContent.Trim(), CultureInfo.InvariantCulture);
        }

        public async Task<long> GetProductCountAsync()
        {
            var httpResponse = await _httpClient.GetAsync("statistics/GetProductCount");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return long.Parse(rawContent.Trim());
        }
    }
}
