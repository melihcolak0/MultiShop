using MultiShop.DTOLayer.RapidAPIDTOs;
using System.Text.Json;

namespace MultiShop.WebUI.Services.RapidAPIServices.WeatherAPIServices
{
    public class WeatherAPIService : IWeatherAPIService
    {
        private readonly HttpClient _httpClient;

        public WeatherAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherAPIDTO.Rootobject> GetWeatherAsync(string city)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://the-weather-api.p.rapidapi.com/api/weather/{city}"),
                Headers =
                {
                    { "x-rapidapi-key", "myrapidapikey" },
                    { "x-rapidapi-host", "the-weather-api.p.rapidapi.com" }
                }
            };

            using var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<WeatherAPIDTO.Rootobject>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return result;
        }
    }
}
