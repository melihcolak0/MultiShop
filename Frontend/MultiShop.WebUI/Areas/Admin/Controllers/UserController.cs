using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CargoDTOs.CargoCustomerDTOs;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserService userService, ICargoCustomerService cargoCustomerService)
        {
            _userService = userService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersList();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserCargoDetails(string userId)
        {
            var cargoCustomer = await _cargoCustomerService.GetCargoCustomerByUserIdAsync(userId);

            return View(new GetCargoCustomerDTO
            {
                CargoCustomerId = cargoCustomer.CargoCustomerId,
                Name = cargoCustomer.Name,
                Surname = cargoCustomer.Surname,
                Address = cargoCustomer.Address,
                City = cargoCustomer.City,
                District = cargoCustomer.District,
                Email = cargoCustomer.Email,
                Phone = cargoCustomer.Phone,
                CargoUserId = cargoCustomer.CargoUserId                
            });
        }

        [HttpPost]
        public async Task<IActionResult> GetUserCargoDetails(UpdateCargoCustomerDTO updateCargoCustomerDTO)
        {
            await _cargoCustomerService.UpdateCargoCustomerAsync(updateCargoCustomerDTO);
            return RedirectToAction("Index");
        }
    }
}
