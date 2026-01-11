using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.DTOLayer.CommentDTOs.UserCommentDTOs;
using MultiShop.WebUI.Areas.Admin.Controllers;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CommentServices.UserCommentServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserCommentController : Controller
    {
        private readonly IUserCommentService _userCommentService;
        private readonly IProductService _productService;

        public UserCommentController(IUserCommentService userCommentService, IProductService productService)
        {
            _userCommentService = userCommentService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userCommentService.GetAllUserCommentsAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUserComment()
        {
            var values = await _productService.GetAllProductAsync();

            List<SelectListItem> products = (from x in values
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName,
                                                 Value = x.ProductId
                                             }).ToList();

            ViewBag.Products = products;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserComment(CreateUserCommentDTO createUserCommentDTO)
        {
            createUserCommentDTO.CreatedDate = DateTime.Now;
            await _userCommentService.CreateUserCommentAsync(createUserCommentDTO);
            return RedirectToAction("Index");            
        }

        public async Task<IActionResult> DeleteUserComment(int id)
        {
            await _userCommentService.DeleteUserCommentAsync(id);
            return RedirectToAction("Index");            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUserComment(int id)
        {
            var values = await _productService.GetAllProductAsync();
            List<SelectListItem> products = (from x in values
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName,
                                                 Value = x.ProductId
                                             }).ToList();
            ViewBag.Products = products;
            
            var value = await _userCommentService.GetUserCommentByIdAsync(id);
            return View(value);            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserComment(UpdateUserCommentDTO updateUserCommentDTO)
        {
            await _userCommentService.UpdateUserCommentAsync(updateUserCommentDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeUserCommentStatus(int id)
        {
            await _userCommentService.ChangeUserCommentStatusAsync(id);
            return RedirectToAction("Index");
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public UserCommentController(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IActionResult> Index()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7047/api/UserComments");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultUserCommentDTO>>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}

//[HttpGet]
//public async Task<IActionResult> CreateUserComment()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Products");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
//            List<SelectListItem> products = (from x in values
//                                             select new SelectListItem
//                                             {
//                                                 Text = x.ProductName,
//                                                 Value = x.ProductId
//                                             }).ToList();

//            ViewBag.Products = products;
//        }
//    }

//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> CreateUserComment(CreateUserCommentDTO createUserCommentDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(createUserCommentDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PostAsync("https://localhost:7047/api/UserComments", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(createUserCommentDTO);
//}

//public async Task<IActionResult> DeleteUserComment(int id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.DeleteAsync($"https://localhost:7047/api/UserComments/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return RedirectToAction("Index");
//}

//[HttpGet]
//public async Task<IActionResult> UpdateUserComment(int id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Products");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
//            List<SelectListItem> products = (from x in values
//                                             select new SelectListItem
//                                             {
//                                                 Text = x.ProductName,
//                                                 Value = x.ProductId
//                                             }).ToList();

//            ViewBag.Products = products;
//        }
//    }

//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync($"https://localhost:7047/api/UserComments/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<GetUserCommentDTO>(jsonData);
//            return View(values);
//        }
//    }
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> UpdateUserComment(UpdateUserCommentDTO updateUserCommentDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(updateUserCommentDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PutAsync("https://localhost:7047/api/UserComments", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(updateUserCommentDTO);
//}

//public async Task<IActionResult> ChangeUserCommentStatus(int id)
//{
//    var client = _httpClientFactory.CreateClient();
//    var content = new StringContent("", Encoding.UTF8, "application/json");
//    var responseMessage = await client.PutAsync($"https://localhost:7047/api/UserComments/ChangeUserCommentStatus/{id}", content);
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        return RedirectToAction("Index");
//    }

//    return RedirectToAction("Index");
//}