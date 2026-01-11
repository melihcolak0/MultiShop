using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ContactDTOs;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDTO createContactDTO)
        {
            createContactDTO.IsRead = false;
            createContactDTO.SendDate = DateTime.Now;

            await _contactService.CreateContactAsync(createContactDTO);
            return RedirectToAction("Index");            
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public ContactController(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//[HttpGet]
//public IActionResult Index()
//{
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> Index(CreateContactDTO createContactDTO)
//{
//    createContactDTO.IsRead = false;
//    createContactDTO.SendDate = DateTime.Now;

//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(createContactDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PostAsync("https://localhost:7252/api/Contacts", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(createContactDTO);
//}