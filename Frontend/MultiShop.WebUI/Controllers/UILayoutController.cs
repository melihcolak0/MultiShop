using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.RapidAPIServices.ChatBotAPIServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {      
        private readonly IChatBotAPIService _chatBotAPIService;

        public UILayoutController(IChatBotAPIService chatBotAPIService)
        {
            _chatBotAPIService = chatBotAPIService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string userMessage)
        {
            //var botReply = await _chatBotAPIService.SendMessageAsync(userMessage);
            //return Json(botReply);
            return View();
        }
    }
}
