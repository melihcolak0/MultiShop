
namespace MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices
{
    public class CommentStatisticService : ICommentStatisticService
    {
        private readonly HttpClient _httpClient;

        public CommentStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetActiveCommentCountAsync()
        {
            var httpResponse = await _httpClient.GetAsync("usercomments/GetActiveCommentCount");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return int.Parse(rawContent.Trim());
        }

        public async Task<int> GetPassiveCommentCountAsync()
        {
            var httpResponse = await _httpClient.GetAsync("usercomments/GetPassiveCommentCount");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return int.Parse(rawContent.Trim());
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            var httpResponse = await _httpClient.GetAsync("usercomments/GetTotalCommentCount");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return int.Parse(rawContent.Trim());
        }
    }
}
