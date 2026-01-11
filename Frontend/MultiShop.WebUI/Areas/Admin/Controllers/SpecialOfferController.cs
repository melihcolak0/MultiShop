using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            var value = await _specialOfferService.GetSpecialOfferByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeSpecialOfferStatus(string id)
        {
            await _specialOfferService.ChangeSpecialOfferStatusAsync(id);
            return RedirectToAction("Index");
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public SpecialOfferController(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IActionResult> Index()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/SpecialOffers");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDTO>>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}

//[HttpGet]
//public IActionResult CreateSpecialOffer()
//{
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDTO createSpecialOfferDTO)
//{
//    createSpecialOfferDTO.Status = false;

//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(createSpecialOfferDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PostAsync("https://localhost:7252/api/SpecialOffers", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(createSpecialOfferDTO);
//}

//public async Task<IActionResult> DeleteSpecialOffer(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.DeleteAsync($"https://localhost:7252/api/SpecialOffers/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return RedirectToAction("Index");
//}

//[HttpGet]
//public async Task<IActionResult> UpdateSpecialOffer(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync($"https://localhost:7252/api/SpecialOffers/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<GetSpecialOfferDTO>(jsonData);
//            return View(values);
//        }
//    }
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDTO updateSpecialOfferDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PutAsync("https://localhost:7252/api/SpecialOffers", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(updateSpecialOfferDTO);
//}

//public async Task<IActionResult> ChangeSpecialOfferStatus(string id)
//{
//    var client = _httpClientFactory.CreateClient();
//    var content = new StringContent("", Encoding.UTF8, "application/json");
//    var responseMessage = await client.PutAsync($"https://localhost:7252/api/SpecialOffers/ChangeSpecialOfferStatus/{id}", content);
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }

//    return RedirectToAction("Index");
//}