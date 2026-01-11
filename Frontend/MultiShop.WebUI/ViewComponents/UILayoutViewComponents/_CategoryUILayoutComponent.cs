using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _CategoryUILayoutComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryUILayoutComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}

// Eski Kodlar Aşağıdadır:

//using (var client = _httpClientFactory.CreateClient())
//{
//    var responseMessage = await client.GetAsync("https://localhost:7252/api/Categories");
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        var jsonData = await responseMessage.Content.ReadAsStringAsync();
//        var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
//        return View(values);
//    }
//}

//return View();