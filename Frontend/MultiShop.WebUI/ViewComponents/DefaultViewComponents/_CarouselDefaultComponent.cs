using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.SliderDTOs;
using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.CatalogServices.SliderServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly ISpecialOfferService _specialOfferService;

        public _CarouselDefaultComponent(ISliderService sliderService, ISpecialOfferService specialOfferService)
        {
            _sliderService = sliderService;
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sliders = await _sliderService.GetAllActiveSlidersAsync();
            var specialOffers = await _specialOfferService.GetAllActiveSpecialOffersAsync();

            var model = new SlidersOffersViewModel
            {
                Sliders = sliders,
                SpecialOffers = specialOffers
            };
            return View(model);
        }
    }
}

// Eski Kodlar Aşağıdadır:

//using (var client = _httpClientFactory.CreateClient())
//{
//    var sliderResponseMessage = await client.GetAsync("https://localhost:7252/api/Sliders/GetActiveSlidersList");
//    var specialOfferResponseMessage = await client.GetAsync("https://localhost:7252/api/SpecialOffers/GetActiveSpecialOffersList");

//    if (sliderResponseMessage.IsSuccessStatusCode && specialOfferResponseMessage.IsSuccessStatusCode)
//    {
//        var sliderJsonData = await sliderResponseMessage.Content.ReadAsStringAsync();
//        var sliders = JsonConvert.DeserializeObject<List<ResultSliderDTO>>(sliderJsonData);

//        var specialOfferJsonData = await specialOfferResponseMessage.Content.ReadAsStringAsync();
//        var specialOffers = JsonConvert.DeserializeObject<List<ResultSpecialOfferDTO>>(specialOfferJsonData);

//        var model = new SlidersOffersViewModel
//        {
//            Sliders = sliders,
//            SpecialOffers = specialOffers
//        };
//        return View(model);
//    }
//}

//return View();