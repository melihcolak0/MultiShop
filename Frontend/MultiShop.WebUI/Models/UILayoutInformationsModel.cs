using MultiShop.DTOLayer.RapidAPIDTOs;
using System.Reflection;

namespace MultiShop.WebUI.Models
{
    public class UILayoutInformationsModel
    {
        public WeatherAPIDTO.Rootobject Weather { get; set; }
        public ExchangeAPIDTO.Rootobject ExchangeUSDTRY { get; set; }
        public ExchangeAPIDTO.Rootobject ExchangeEURTRY { get; set; }
    }
}
