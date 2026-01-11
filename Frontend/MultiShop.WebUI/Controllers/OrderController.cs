using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.OrderDTOs.AddressDTOs;
using MultiShop.DTOLayer.OrderDTOs.OrderDetailDTOs;
using MultiShop.DTOLayer.OrderDTOs.OrderDTOs;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.OrderServices.AddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderDetailServices;
using MultiShop.WebUI.Services.OrderServices.OrderServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;        
        private readonly IOrderDetailService _orderDetailService;
        private readonly IAddressService _addressService;
        private readonly IBasketService _basketService;

        public OrderController(IOrderService orderService, IUserService userService, IAddressService addressService, IOrderDetailService orderDetailService, IBasketService basketService)
        {
            _orderService = orderService;
            _userService = userService;
            _addressService = addressService;
            _orderDetailService = orderDetailService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {         
            var user = await _userService.GetUserInfo();
            ViewBag.userId = user.Id;
            ViewBag.name = user.Name;
            ViewBag.surname = user.Surname;
            ViewBag.email = user.Email;
            ViewBag.phone = "+90 123 456 78 90";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDTO createAddressDTO)
        {
            await _addressService.CreateAddressAsync(createAddressDTO);

            var basket = await _basketService.GetBasketAsync();

            var order = new CreateOrderDTO
            {
                UserId = createAddressDTO.UserId,
                IsPaid = true,
                OrderDate = DateTime.Now,
                TotalPrice = basket.GrandTotal
            };

            int orderId = await _orderService.CreateOrderReturnIdAsync(order);

            foreach (var item in basket.BasketItems)
            {
                var orderDetail = new CreateOrderDetailDTO
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Amount = item.Quantity,
                    ProductPrice = item.Price,
                    TotalPrice = item.Quantity * item.Price,
                    OrderId = orderId
                };

                await _orderDetailService.CreateOrderDetailAsync(orderDetail);
            }

            await _basketService.ClearBasketAsync();
            await _basketService.ClearDiscountAsync();

            return RedirectToAction("Index", "Payment");
        }
    }
}
