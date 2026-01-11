
namespace MultiShop.WebUI.Services.SignalRServices.SignalRMessageServices
{
    public class SignalRMessageService : ISignalRMessageService
    {
        private readonly HttpClient _httpClient;

        public SignalRMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
