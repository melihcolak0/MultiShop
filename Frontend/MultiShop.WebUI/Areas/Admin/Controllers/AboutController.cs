using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.AboutDTOs;
using MultiShop.WebUI.Areas.Admin.Controllers;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            await _aboutService.CreateAboutAsync(createAboutDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            var value = await _aboutService.GetAboutByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeAboutStatus(string id)
        {
            await _aboutService.ChangeAboutStatusAsync(id);
            return RedirectToAction("Index");
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public AboutController(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IActionResult> Index()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Abouts");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}

//[HttpGet]
//public IActionResult CreateAbout()
//{
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
//{
//    createAboutDTO.Status = true;

//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(createAboutDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PostAsync("https://localhost:7252/api/Abouts", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(createAboutDTO);
//}

//public async Task<IActionResult> DeleteAbout(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.DeleteAsync($"https://localhost:7252/api/Abouts/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return RedirectToAction("Index");
//}

//[HttpGet]
//public async Task<IActionResult> UpdateAbout(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync($"https://localhost:7252/api/Abouts/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<GetAboutDTO>(jsonData);
//            return View(values);
//        }
//    }
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(updateAboutDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PutAsync("https://localhost:7252/api/Abouts", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(updateAboutDTO);
//}

//public async Task<IActionResult> ChangeAboutStatus(string id)
//{
//    var client = _httpClientFactory.CreateClient();
//    var content = new StringContent("", Encoding.UTF8, "application/json");
//    var responseMessage = await client.PutAsync($"https://localhost:7252/api/Abouts/ChangeAboutStatus/{id}", content);
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }

//    return RedirectToAction("Index");
//}