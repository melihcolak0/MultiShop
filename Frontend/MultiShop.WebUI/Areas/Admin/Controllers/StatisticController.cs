using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticsServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IUserStatisticsService _userStatisticsService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticsService userStatisticsService, ICommentStatisticService commentStatisticService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticsService = userStatisticsService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryCount = await _catalogStatisticService.GetCategoryCountAsync();
            var productCount = await _catalogStatisticService.GetProductCountAsync();
            var productsAvgPrice = await _catalogStatisticService.GetProductAvgPriceAsync();
            var minPriceProductName = await _catalogStatisticService.GetMinPriceProductNameAsync();
            var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductNameAsync();
            var brandCount = "15";
            var userCount = await _userStatisticsService.GetUserCountAsync();
            var activeCommentCount = await _commentStatisticService.GetActiveCommentCountAsync();
            var passiveCommentCount = await _commentStatisticService.GetPassiveCommentCountAsync();
            var totalCommentCount = await _commentStatisticService.GetTotalCommentCountAsync();
            var couponCount = await _discountStatisticService.GetCoupunCountAsync();
            var totalMessageCount = await _messageStatisticService.GetTotalMessageCount();

            ViewBag.CategoryCount = categoryCount;
            ViewBag.ProductCount = productCount;
            ViewBag.ProductsAvgPrice = productsAvgPrice.ToString("N2");
            ViewBag.MinPriceProductName = minPriceProductName;
            ViewBag.MaxPriceProductName = maxPriceProductName;
            ViewBag.BrandCount = brandCount;
            ViewBag.UserCount = userCount;
            ViewBag.ActiveCommentCount = activeCommentCount;
            ViewBag.PassiveCommentCount = passiveCommentCount;
            ViewBag.TotalCommentCount = totalCommentCount;
            ViewBag.CouponCount = couponCount;
            ViewBag.TotalMessageCount = totalMessageCount;

            return View();
        }
    }
}
