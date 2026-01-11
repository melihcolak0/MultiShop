
using System.Net.Http;

namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public class MessageStatisticService : IMessageStatisticService
    {
        private readonly HttpClient _httpClient;

        public MessageStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }        

        public async Task<int> GetTotalMessageCount()
        {
            var httpResponse = await _httpClient.GetAsync("usermessage/GetTotalMessageCount");
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
