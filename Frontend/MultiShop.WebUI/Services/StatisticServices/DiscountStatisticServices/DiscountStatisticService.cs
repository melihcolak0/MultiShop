
namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
    public class DiscountStatisticService : IDiscountStatisticService
    {
        private readonly HttpClient _httpClient;

        public DiscountStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetCoupunCountAsync()
        {
            var httpResponse = await _httpClient.GetAsync("coupons/GetCoupunCount");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return int.Parse(rawContent.Trim());
        }
    }
}
