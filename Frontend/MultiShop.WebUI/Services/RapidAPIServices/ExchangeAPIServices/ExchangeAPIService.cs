using MultiShop.DTOLayer.RapidAPIDTOs;
using System.Text.Json;

namespace MultiShop.WebUI.Services.RapidAPIServices.ExchangeAPIServices
{
    public class ExchangeAPIService : IExchangeAPIService
    {
        private readonly HttpClient _httpClient;

        public ExchangeAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExchangeAPIDTO.Rootobject> GetExchangeRateAsync(string fromSymbol, string toSymbol)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(
                    $"https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate" +
                    $"?from_symbol={fromSymbol}&to_symbol={toSymbol}&language=en"
                ),
                Headers =
                {
                    { "x-rapidapi-key", "myrapidapikey" },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" }
                }
            };

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ExchangeAPIDTO.Rootobject>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );
        }
    }
}
