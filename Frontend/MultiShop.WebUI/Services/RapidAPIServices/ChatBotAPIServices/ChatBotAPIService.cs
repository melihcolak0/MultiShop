using MultiShop.DTOLayer.RapidAPIDTOs;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Services.RapidAPIServices.ChatBotAPIServices
{
    public class ChatBotAPIService : IChatBotAPIService
    {
        private readonly HttpClient _httpClient;

        public ChatBotAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendMessageAsync(string message)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://chat-gpt26.p.rapidapi.com/"),
                Headers =
                {
                    { "x-rapidapi-key", "myrapidapikey" },
                    { "x-rapidapi-host", "chat-gpt26.p.rapidapi.com" }
                },
                Content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        model = "GPT-5-mini",
                        messages = new[]
                        {
                            new { role = "user", content = message }
                        }
                    }),
                    Encoding.UTF8,
                    "application/json"
                )
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ChatBotAPIDTO.Rootobject>(json);

            return result?.choices?.FirstOrDefault()?.message?.content ?? "Cevap alınamadı.";
        }
    }
}
