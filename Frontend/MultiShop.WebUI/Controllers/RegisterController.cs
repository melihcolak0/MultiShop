using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.IdentityDTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDTO registerDTO)
        {
            if(registerDTO.ConfirmPassword == registerDTO.Password)
            {
                using (var client = _httpClientFactory.CreateClient())
                {
                    var jsonData = JsonConvert.SerializeObject(registerDTO);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "LogIn");
                    }
                }
            }
           
            return View(registerDTO);
        }
    }
}
