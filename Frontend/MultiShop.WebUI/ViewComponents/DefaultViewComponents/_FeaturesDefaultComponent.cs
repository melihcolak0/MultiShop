using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.FeatureDTOs;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.ViewComponents.DefaultViewComponents;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeaturesDefaultComponent : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _FeaturesDefaultComponent(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllActiveFeaturesAsync();
            return View(values);            
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public _FeaturesDefaultComponent(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}
//public async Task<IViewComponentResult> InvokeAsync()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Features/GetActiveFeaturesList");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultFeatureDTO>>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}