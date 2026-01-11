using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;
using MultiShop.WebUI.Areas.Admin.Controllers;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;

        public ProductImageController(IProductImageService productImageService, IProductService productService)
        {
            _productImageService = productImageService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _productImageService.GetAllProductImageWithProductAsync();
            return View(values);            
        }

        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
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
        public async Task<IActionResult> CreateProductImage(CreateProductImageDTO createProductImageDTO)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDTO);
            return RedirectToAction("Index");         
        }

        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return RedirectToAction("Index");            
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            var values = await _productService.GetAllProductAsync();
            List<SelectListItem> products = (from x in values
                                             select new SelectListItem
                                             {
                                                 Text = x.ProductName,
                                                 Value = x.ProductId
                                             }).ToList();

            ViewBag.Products = products;

            var value = await _productImageService.GetProductImageByIdAsync(id);
            return View(value);           
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO updateProductImageDTO)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProductImageByProductId(string id)
        {
            var value = await _productImageService.GetProductImageByProductIdAsync(id);
            return View(value);            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductImageByProductId(UpdateProductImageDTO updateProductImageDTO)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDTO);
            return RedirectToAction("Index");           
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public ProductImageController(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IActionResult> Index()
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync("https://localhost:7252/api/ProductImages/GetProductImagesListWithProduct");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<List<ResultProductImageWithProductDTO>>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}

//[HttpGet]
//public async Task<IActionResult> CreateProductImage()
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
//public async Task<IActionResult> CreateProductImage(CreateProductImageDTO createProductImageDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(createProductImageDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PostAsync("https://localhost:7252/api/ProductImages", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(createProductImageDTO);
//}

//public async Task<IActionResult> DeleteProductImage(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.DeleteAsync($"https://localhost:7252/api/ProductImages/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return RedirectToAction("Index");
//}

//[HttpGet]
//public async Task<IActionResult> UpdateProductImage(string id)
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
//        var responseMessage = await client.GetAsync($"https://localhost:7252/api/ProductImages/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<GetProductImageDTO>(jsonData);
//            return View(values);
//        }
//    }
//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO updateProductImageDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(updateProductImageDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PutAsync("https://localhost:7252/api/ProductImages", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(updateProductImageDTO);
//}

//[HttpGet]
//public async Task<IActionResult> UpdateProductImageByProductId(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var responseMessage = await client.GetAsync($"https://localhost:7252/api/ProductImages/GetProductImageByProductId/{id}");
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            var jsonData = await responseMessage.Content.ReadAsStringAsync();
//            var values = JsonConvert.DeserializeObject<GetProductImageDTO>(jsonData);
//            return View(values);
//        }
//    }

//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> UpdateProductImageByProductId(UpdateProductImageDTO updateProductImageDTO)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var jsonData = JsonConvert.SerializeObject(updateProductImageDTO);
//        StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//        var responseMessage = await client.PutAsync("https://localhost:7252/api/ProductImages", stringContent);
//        if (responseMessage.IsSuccessStatusCode)
//        {
//            return RedirectToAction("Index");
//        }
//    }
//    return View(updateProductImageDTO);
//}