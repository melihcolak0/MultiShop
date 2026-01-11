using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;
using MultiShop.DTOLayer.CommentDTOs.UserCommentDTOs;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CommentServices.UserCommentServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductDetailService _productDetailService;
        private readonly IProductImageService _productImageService;
        private readonly IUserCommentService _userCommentService;

        public ProductsController(IProductService productService, IProductDetailService productDetailService, IProductImageService productImageService, IUserCommentService userCommentService)
        {
            _productService = productService;
            _productDetailService = productDetailService;
            _productImageService = productImageService;
            _userCommentService = userCommentService;
        }

        public async Task<IActionResult> Index(ResultProductByFilterDTO filter)
        {
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
            filter.ViewMode ??= "grid";

            ViewBag.MinPrice = (int)await _productService.GetMinProductPrice();
            ViewBag.MaxPrice = (int)Math.Ceiling(await _productService.GetMaxProductPrice());

            return View();
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            var productBasics = await _productService.GetProductByIdAsync(id);
            var productDetails = await _productDetailService.GetProductDetailByProductIdAsync(id);
            var productImages = await _productImageService.GetProductImageByProductIdAsync(id);

            var model = new ProductDetailModel
            {
                ProductBasics = productBasics,
                ProductDetails = productDetails,
                ProductImages = productImages,
                CreateComment = new CreateUserCommentDTO()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserComment(CreateUserCommentDTO dto)
        {
            dto.CreatedDate = DateTime.Now;
            dto.Status = false;
            dto.ImageUrl = "";

            await _userCommentService.CreateUserCommentAsync(dto);
            return RedirectToAction("ProductDetail", new { id = dto.ProductId });            
        }
    }
}

// Eski Kodlar Aşağıdadır:

//private readonly IHttpClientFactory _httpClientFactory;

//public ProductsController(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IActionResult> Index(ResultProductByFilterDTO filter)
//{
//    filter.ViewMode = string.IsNullOrEmpty(filter.ViewMode) ? "grid" : filter.ViewMode;

//    var client = _httpClientFactory.CreateClient();

//    // Kategori Id boş ise querystring'den çek
//    filter.CategoryId = string.IsNullOrEmpty(filter.CategoryId)
//? HttpContext.Request.Query["CategoryId"]
//: filter.CategoryId;

//    // Min fiyat
//    var minPriceResponse = await client.GetAsync("https://localhost:7252/api/Products/GetMinProductPrice");
//    var minPrice = minPriceResponse.IsSuccessStatusCode
//        ? await minPriceResponse.Content.ReadFromJsonAsync<decimal>()
//        : 0;

//    // Max fiyat
//    var maxPriceResponse = await client.GetAsync("https://localhost:7252/api/Products/GetMaxProductPrice");
//    var maxPrice = maxPriceResponse.IsSuccessStatusCode
//        ? await maxPriceResponse.Content.ReadFromJsonAsync<decimal>()
//        : 1000;

//    ViewBag.MinPrice = (int)minPrice;
//    ViewBag.MaxPrice = (int)Math.Ceiling(maxPrice);

//    // Filtreli ürünleri çağır
//    var response = await client.PostAsJsonAsync(
//        "https://localhost:7252/api/Products/GetProductsByFilter", filter);

//    if (!response.IsSuccessStatusCode)
//        return View(new PagedResult<ResultProductDTO> { Items = new List<ResultProductDTO>() });

//    var result = await response.Content.ReadFromJsonAsync<PagedResult<ResultProductDTO>>();
//    return View(result);
//}

//public async Task<IActionResult> ProductDetail(string id)
//{
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var productBasicResponse = await client.GetAsync($"https://localhost:7252/api/Products/{id}");
//        var productDetailResponse = await client.GetAsync($"https://localhost:7252/api/ProductDetails/GetProductDetailByProductId/{id}");
//        var productImageResponse = await client.GetAsync($"https://localhost:7252/api/ProductImages/GetProductImageByProductId/{id}");
//        if (productBasicResponse.IsSuccessStatusCode && productDetailResponse.IsSuccessStatusCode && productImageResponse.IsSuccessStatusCode)
//        {
//            var productBasicjsonData = await productBasicResponse.Content.ReadAsStringAsync();
//            var productBasics = JsonConvert.DeserializeObject<GetProductDTO>(productBasicjsonData);

//            var productDetailjsonData = await productDetailResponse.Content.ReadAsStringAsync();
//            var productDetails = JsonConvert.DeserializeObject<GetProductDetailDTO>(productDetailjsonData);

//            var productImagejsonData = await productImageResponse.Content.ReadAsStringAsync();
//            var productImages = JsonConvert.DeserializeObject<GetProductImageDTO>(productImagejsonData);

//            var model = new ProductDetailModel
//            {
//                ProductBasics = productBasics,
//                ProductDetails = productDetails,
//                ProductImages = productImages,
//                CreateComment = new CreateUserCommentDTO()
//            };

//            return View(model);
//        }
//    }

//    return View();
//}

//[HttpPost]
//public async Task<IActionResult> CreateUserComment(CreateUserCommentDTO dto)
//{
//    dto.CreatedDate = DateTime.Now;
//    dto.Status = false;
//    dto.ImageUrl = "";
//    using (var client = _httpClientFactory.CreateClient())
//    {
//        var json = JsonConvert.SerializeObject(dto);
//        var content = new StringContent(json, Encoding.UTF8, "application/json");

//        var response = await client.PostAsync("https://localhost:7047/api/UserComments", content);
//        if (response.IsSuccessStatusCode)
//        {
//            return RedirectToAction("ProductDetail", new { id = dto.ProductId });
//        }
//    }
//    return RedirectToAction("ProductDetail", new { id = dto.ProductId });
//}