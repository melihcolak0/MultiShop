using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.OrderDTOs.OrderDTOs;
using MultiShop.WebUI.Services.OrderServices.OrderDetailServices;
using MultiShop.WebUI.Services.OrderServices.OrderServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _orderService.GetAllOrdersAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var orderDetails = await _orderDetailService.GetOrderDetailsByOrderId(id);
            return View(orderDetails);
        }

        //[HttpGet]
        //public IActionResult CreateOrder()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateOrder(CreateOrderDTO createOrderDTO)
        //{
        //    await _orderService.CreateOrderAsync(createOrderDTO);
        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> DeleteOrder(string id)
        //{
        //    await _orderService.DeleteOrderAsync(id);
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public async Task<IActionResult> UpdateOrder(string id)
        //{
        //    var value = await _orderService.GetOrderByIdAsync(id);
        //    return View(value);
        //}

        //[HttpPost]
        //public async Task<IActionResult> UpdateOrder(UpdateOrderDTO updateOrderDTO)
        //{
        //    await _orderService.UpdateOrderAsync(updateOrderDTO);
        //    return RedirectToAction("Index");
        //}
    }
}
