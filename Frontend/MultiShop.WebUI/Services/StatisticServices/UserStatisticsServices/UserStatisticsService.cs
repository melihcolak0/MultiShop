
namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticsServices
{
    public class UserStatisticsService : IUserStatisticsService
    {
        private readonly HttpClient _httpClient;

        public UserStatisticsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<int> GetUserCountAsync()
        {
            var httpResponse = await _httpClient.GetAsync("api/statistics/getusercount");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return int.Parse(rawContent.Trim());
        }
    }
}
