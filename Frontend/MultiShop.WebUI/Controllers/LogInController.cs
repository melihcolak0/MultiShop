using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.IdentityDTOs;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class LogInController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogInService _logInService;
        private readonly IIdentityService _identityService;

        public LogInController(IHttpClientFactory httpClientFactory, ILogInService logInService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _logInService = logInService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDTO signInDTO)
        {            
            await _identityService.SignIn(signInDTO);
            return RedirectToAction("Index", "User");
        }
        
        public async Task<IActionResult> LogOut()
        {
            await _identityService.SignOut();
            return RedirectToAction("Index", "LogIn");
        }

        //[HttpGet]
        //public IActionResult SignIn()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> SignIn(SignInDTO signInDTO)
        //{
            
        //}
    }
}


//var client = _httpClientFactory.CreateClient();
//var content = new StringContent(JsonSerializer.Serialize(logInDTO), Encoding.UTF8, "application/json");
//var response = await client.PostAsync("http://localhost:5001/api/LogIns", content);
//if (response.IsSuccessStatusCode)
//{
//    var jsonData = await response.Content.ReadAsStringAsync();
//    var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
//    {
//        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
//    });

//    if (tokenModel != null)
//    {
//        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
//        var token = handler.ReadJwtToken(tokenModel.Token);
//        var claims = token.Claims.ToList();

//        if (tokenModel.Token != null)
//        {
//            claims.Add(new Claim("multishoptoken", tokenModel.Token));
//            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
//            var authProps = new AuthenticationProperties
//            {
//                ExpiresUtc = tokenModel.ExpireDate,
//                IsPersistent = true
//            };

//            await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

//            //var userId = _logInService.GetUserId;

//            var userId = claims
//            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)
//            ?.Value;

//            return RedirectToAction("Index", "Default");
//        }
//    }
//}
//return View();