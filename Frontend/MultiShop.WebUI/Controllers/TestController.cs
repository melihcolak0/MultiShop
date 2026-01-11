using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.RapidAPIServices.WeatherAPIServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWeatherAPIService _weatherAPIService;

        public TestController(IHttpClientFactory httpClientFactory, IWeatherAPIService weatherAPIService)
        {
            _httpClientFactory = httpClientFactory;
            _weatherAPIService = weatherAPIService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string token = "";

            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        { "client_id", "MultiShopVisitorId" },
                        { "client_secret", "multishopsecret" },
                        { "grant_type", "client_credentials" }
                    })
                };

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);
                        token = tokenResponse["access_token"].ToString();
                    }
                }
            }

            using (var client = _httpClientFactory.CreateClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // !!!

                var responseMessage = await client.GetAsync("https://localhost:7252/api/Categories");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
                    return View(values);
                }
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Deneme(string city = "istanbul")
        {
            //var weather = await _weatherAPIService.GetWeatherAsync(city);
            //weather.data.current_weather = "sun";
            //return View(weather);
            return View();
        }
    }
}
