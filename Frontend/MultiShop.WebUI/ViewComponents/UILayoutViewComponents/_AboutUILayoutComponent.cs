using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.AboutDTOs;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _AboutUILayoutComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public _AboutUILayoutComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllActiveAboutsAsync();
            return View(values);
        }
    }
}

// Eski Kodlar Aşağıdadır:

//using (var client = _httpClientFactory.CreateClient())
//{
//    var responseMessage = await client.GetAsync("https://localhost:7252/api/Abouts/GetActiveAboutsList");
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        var jsonData = await responseMessage.Content.ReadAsStringAsync();
//        var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
//        return View(values);
//    }
//}

//return View();