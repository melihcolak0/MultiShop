using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetAllProductsWithCategory();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var values = await _categoryService.GetAllCategoryAsync();

            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId
                                               }).ToList();

            ViewBag.Categories = categories;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productService.CreateProductAsync(createProductDTO);            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _categoryService.GetAllCategoryAsync();

            List<SelectListItem> categories = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId
                                               }).ToList();

            ViewBag.Categories = categories;

            var value = await _productService.GetProductByIdAsync(id);            
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productService.UpdateProductAsync(updateProductDTO);
            return RedirectToAction("Index");
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public ProductController(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IActionResult> Index()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Products/GetProductsListWithCategory");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDTO>>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}

//[HttpGet]
//public async Task<IActionResult> CreateProduct()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Categories");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
//            List<SelectListItem> categories = (from x in values
//                                               select new SelectListItem
//                                               {
//                                                   Text = x.CategoryName,
//                                                   Value = x.CategoryId
//                                               }).ToList();

//            ViewBag.Categories = categories;
//        }
//    }

//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(createProductDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PostAsync("https://localhost:7252/api/Products", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(createProductDTO);
//}

//public async Task<IActionResult> DeleteProduct(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.DeleteAsync($"https://localhost:7252/api/Products/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return RedirectToAction("Index");
//}

//[HttpGet]
//public async Task<IActionResult> UpdateProduct(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/Categories");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(jsonData);
//            List<SelectListItem> categories = (from x in values
//                                               select new SelectListItem
//                                               {
//                                                   Text = x.CategoryName,
//                                                   Value = x.CategoryId
//                                               }).ToList();

//            ViewBag.Categories = categories;
//        }
//    }

//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync($"https://localhost:7252/api/Products/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<GetProductDTO>(jsonData);
//            return View(values);
//        }
//    }
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(updateProductDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PutAsync("https://localhost:7252/api/Products", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(updateProductDTO);
//}