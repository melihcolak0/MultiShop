using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ContactDTOs;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactService.GetAllContactAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
        {
            createContactDTO.IsRead = false;
            createContactDTO.SendDate = DateTime.Now;

            await _contactService.CreateContactAsync(createContactDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(string id)
        {
            var value = await _contactService.GetContactByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO updateContactDTO)
        {
            await _contactService.UpdateContactAsync(updateContactDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeContactReading(string id)
        {
            await _contactService.ChangeContactReadingAsync(id);
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

//public async Task<IActionResult> Index()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Contacts");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultContactDTO>>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}

//[HttpGet]
//public IActionResult CreateContact()
//{
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> CreateContact(CreateContactDTO createContactDTO)
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

//public async Task<IActionResult> DeleteContact(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.DeleteAsync($"https://localhost:7252/api/Contacts/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return RedirectToAction("Index");
//}

//[HttpGet]
//public async Task<IActionResult> UpdateContact(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync($"https://localhost:7252/api/Contacts/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<GetContactDTO>(jsonData);
//            return View(values);
//        }
//    }
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> UpdateContact(UpdateContactDTO updateContactDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(updateContactDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PutAsync("https://localhost:7252/api/Contacts", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(updateContactDTO);
//}

//public async Task<IActionResult> ChangeContactReading(string id)
//{
//    var client = _httpClientFactory.CreateClient();
//    var content = new StringContent("", Encoding.UTF8, "application/json");
//    var responseMessage = await client.PutAsync($"https://localhost:7252/api/Contacts/ChangeContactReading/{id}", content);
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }

//    return RedirectToAction("Index");
//}