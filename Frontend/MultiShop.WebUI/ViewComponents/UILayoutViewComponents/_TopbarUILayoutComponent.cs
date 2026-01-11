using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.RapidAPIDTOs;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.RapidAPIServices.ExchangeAPIServices;
using MultiShop.WebUI.Services.RapidAPIServices.WeatherAPIServices;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponent : ViewComponent
    {
        private readonly IWeatherAPIService _weatherAPIService;
        private readonly IExchangeAPIService _exchangeAPIService;

        public _TopbarUILayoutComponent(IWeatherAPIService weatherAPIService, IExchangeAPIService exchangeAPIService)
        {
            _weatherAPIService = weatherAPIService;
            _exchangeAPIService = exchangeAPIService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Test Verileri
            var weather = new WeatherAPIDTO.Rootobject
            {
                success = true,
                data = new WeatherAPIDTO.Data
                {
                    city = "Fatih, Istanbul, Türkiye",
                    current_weather = "Mostly Cloudy",
                    temp = "15"
                }
            };
            var usdTry = new ExchangeAPIDTO.Rootobject
            {
                status = "OK",
                data = new ExchangeAPIDTO.Data
                {
                    from_symbol = "USD",
                    to_symbol = "TRY",
                    exchange_rate = 42.95m
                }
            };
            var eurTry = new ExchangeAPIDTO.Rootobject
            {
                status = "OK",
                data = new ExchangeAPIDTO.Data
                {
                    from_symbol = "EUR",
                    to_symbol = "TRY",
                    exchange_rate = 46.80m
                }
            };

            //var weather = await _weatherAPIService.GetWeatherAsync("istanbul");
            //var usdTry = await _exchangeAPIService.GetExchangeRateAsync("USD", "TRY");
            //var eurTry = await _exchangeAPIService.GetExchangeRateAsync("EUR", "TRY");

            return View(new UILayoutInformationsModel
            {
                Weather = weather,
                ExchangeEURTRY = usdTry,
                ExchangeUSDTRY = eurTry
            });           
        }
    }
}

// Hava Durumu API'si

//var weather = await _weatherAPIService.GetWeatherAsync("istanbul");

//var weather = new WeatherAPIDTO.Rootobject
//{
//    success = true,
//    data = new WeatherAPIDTO.Data
//    {
//        city = "Fatih, Istanbul, Türkiye",
//        current_weather = "Mostly Cloudy",
//        temp = "15",
//        expected_temp = "Day 15° • Night 9°",
//        insight_heading = "Rain",
//        insight_description = "Rain possible after 7:00 pm.",
//        wind = "37 km/h",
//        humidity = "66%",
//        visibility = "9.66 km",
//        uv_index = "1 of 11",
//        aqi = "31",
//        aqi_remark = "Good",
//        aqi_description = "Minimal impact.",
//        last_update = "14:35 GMT+03:00",
//        bg_image = "https://s.w-x.co/WeatherImages_Web/WeatherImage_MostlyCloudy-day_5.jpg"
//    }
//};

//return View(new UILayoutInformationsModel
//{
//    Weather = weather
//});