using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CommentDTOs.UserCommentDTOs;
using MultiShop.WebUI.Services.CommentServices.UserCommentServices;
using MultiShop.WebUI.ViewComponents.ProductDetailViewComponents;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _CommentListProductDetailComponent : ViewComponent
    {
        private readonly IUserCommentService _userCommentService;

        public _CommentListProductDetailComponent(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _userCommentService.GetUserCommentsListByProductIdAsync(id);
            return View(values);
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public _CommentListProductDetailComponent(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IViewComponentResult> InvokeAsync(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync($"http://localhost:7047/api/UserComments/GetUserCommentsListByProductId/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultUserCommentDTO>>(jsonData);
//            return View(values);
//        }
//    }
//    return View();
//}