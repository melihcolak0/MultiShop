using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.ViewComponents.ProductViewComponents;
using System.Net.Http;

namespace MultiShop.WebUI.ViewComponents.ProductViewComponents
{
    public class _ProductListByModeProductComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public _ProductListByModeProductComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(ResultProductByFilterDTO filter)
        {
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
            filter.ViewMode ??= "grid";

            var result = await _productService.GetProductsByFilterAsync(filter);

            // Boş sayfa varsa geri çek
            int totalPages = (int)Math.Ceiling((double)result.TotalCount / filter.PageSize);
            if (filter.Page > totalPages && totalPages > 0)
            {
                filter.Page = 1;
                result = await _productService.GetProductsByFilterAsync(filter);
            }

            return View(filter.ViewMode == "list" ? "ListView" : "GridView", result);           
        }
    }
}

//private readonly IHttpClientFactory _httpClientFactory;

//public _ProductListByModeProductComponent(IHttpClientFactory httpClientFactory)
//{
//    _httpClientFactory = httpClientFactory;
//}

//public async Task<IViewComponentResult> InvokeAsync(ResultProductByFilterDTO filter)
//{
//    // Default değerler
//    filter.Page = filter.Page <= 0 ? 1 : filter.Page;
//    filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;
//    filter.ViewMode = string.IsNullOrEmpty(filter.ViewMode) ? "grid" : filter.ViewMode;

//    try
//    {
//        var client = _httpClientFactory.CreateClient();
//        var response = await client.PostAsJsonAsync(
//            "https://localhost:7252/api/Products/GetProductsByFilter",
//            filter
//        );

//        if (!response.IsSuccessStatusCode)
//        {
//            // Boş liste döndür
//            return View("GridView", new PagedResult<ResultProductDTO>
//            {
//                Items = new List<ResultProductDTO>(),
//                PageNumber = filter.Page,
//                PageSize = filter.PageSize,
//                TotalCount = 0
//            });
//        }

//        var pagedResult = await response.Content
//            .ReadFromJsonAsync<PagedResult<ResultProductDTO>>();

//        if (pagedResult == null)
//        {
//            pagedResult = new PagedResult<ResultProductDTO>
//            {
//                Items = new List<ResultProductDTO>(),
//                PageNumber = filter.Page,
//                PageSize = filter.PageSize,
//                TotalCount = 0
//            };
//        }

//        var viewName = filter.ViewMode == "list" ? "ListView" : "GridView";
//        return View(viewName, pagedResult);
//    }
//    catch
//    {
//        // Exception oluşursa da boş liste döndür
//        return View("GridView", new PagedResult<ResultProductDTO>
//        {
//            Items = new List<ResultProductDTO>(),
//            PageNumber = filter.Page,
//            PageSize = filter.PageSize,
//            TotalCount = 0
//        });
//    }


//    //var client = _httpClientFactory.CreateClient();

//    //var response = await client.PostAsJsonAsync(
//    //    "https://localhost:7252/api/Products/GetProductsByFilter",
//    //    filter
//    //);

//    //if (!response.IsSuccessStatusCode)
//    //{
//    //    return View("Error");
//    //}

//    //var pagedResult = await response.Content
//    //    .ReadFromJsonAsync<PagedResult<ResultProductDTO>>();

//    //var viewName = filter.ViewMode == "list"
//    //    ? "ListView"
//    //    : "GridView";

//    //return View(viewName, pagedResult);
//}