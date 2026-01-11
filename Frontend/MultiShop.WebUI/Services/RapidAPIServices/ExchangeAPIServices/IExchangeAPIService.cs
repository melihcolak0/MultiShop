using MultiShop.DTOLayer.RapidAPIDTOs;

namespace MultiShop.WebUI.Services.RapidAPIServices.ExchangeAPIServices
{
    public interface IExchangeAPIService
    {
        Task<ExchangeAPIDTO.Rootobject> GetExchangeRateAsync(string fromSymbol, string toSymbol);
    }
}
