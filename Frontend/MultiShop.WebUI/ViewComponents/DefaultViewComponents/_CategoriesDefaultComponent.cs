using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.ViewComponents.DefaultViewComponents;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoriesDefaultComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoriesWithProductCountAsync();
            return View(values);
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public _CategoriesDefaultComponent(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IViewComponentResult> InvokeAsync()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Categories");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}