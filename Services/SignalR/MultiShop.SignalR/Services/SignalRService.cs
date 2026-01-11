
namespace MultiShop.SignalR.Services
{
    public class SignalRService : ISignalRService
    {
        private readonly HttpClient _httpClient;

        public SignalRService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetTotalCommentCountAsync()
        {
            var httpResponse = await _httpClient.GetAsync("usercomments/GetTotalCommentCount");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return int.Parse(rawContent.Trim());
        }

        public async Task<int> GetTotalMessageCountByReceiverIdAsync(string id)
        {
            var httpResponse = await _httpClient.GetAsync($"usermessage/GetTotalMessageCountByReceiverIdAsync?id={id}");
            var rawContent = await httpResponse.Content.ReadAsStringAsync();
            httpResponse.EnsureSuccessStatusCode();
            return int.Parse(rawContent.Trim());
        }
    }
}
