using MultiShop.DTOLayer.RapidAPIDTOs;

namespace MultiShop.WebUI.Services.RapidAPIServices.WeatherAPIServices
{
    public interface IWeatherAPIService
    {
        Task<WeatherAPIDTO.Rootobject> GetWeatherAsync(string city);
    }
}
