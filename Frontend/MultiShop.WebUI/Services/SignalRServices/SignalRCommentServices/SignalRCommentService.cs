
namespace MultiShop.WebUI.Services.SignalRServices.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly HttpClient _httpClient;

        public SignalRCommentService(HttpClient httpClient)
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
    }
}
