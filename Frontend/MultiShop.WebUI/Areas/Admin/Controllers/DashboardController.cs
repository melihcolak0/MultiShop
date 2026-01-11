using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IProductService _productService;

        public DashboardController(IProductService productService)
        {
            _productService = productService;
        }               

        public async Task<IActionResult> Index()
        {
            var values = await _productService.GetProductCountByCategoryAsync();
            return View(new DashboardViewModel
            {
                CategoryProducts = values
            });
        }
    }
}
