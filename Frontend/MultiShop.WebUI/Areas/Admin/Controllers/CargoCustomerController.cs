using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.CargoDTOs.CargoCustomerDTOs;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoCustomerController : Controller
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IUserService _userService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService, IUserService userService)
        {
            _cargoCustomerService = cargoCustomerService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var cargoCustomers = await _cargoCustomerService.GetAllCargoCustomersAsync();
            return View(cargoCustomers);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCargoCustomer()
        {
            var values = await _userService.GetAllUsersList();
            
            List<SelectListItem> users = (from x in values
                                               select new SelectListItem
                                               {
                                                   Text = x.name + " " + x.surname,
                                                   Value = x.id
                                               }).ToList();

            ViewBag.Users = users;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer(CreateCargoCustomerDTO createCargoCustomerDTO)
        {
            await _cargoCustomerService.CreateCargoCustomerAsync(createCargoCustomerDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCargoCustomer(int id)
        {
            await _cargoCustomerService.DeleteCargoCustomerAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCustomer(int id)
        {
            var values = await _userService.GetAllUsersList();

            List<SelectListItem> users = (from x in values
                                          select new SelectListItem
                                          {
                                              Text = x.name + " " + x.surname,
                                              Value = x.id
                                          }).ToList();

            ViewBag.Users = users;

            var value = await _cargoCustomerService.GetCargoCustomerByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoCustomer(UpdateCargoCustomerDTO updateCargoCustomerDTO)
        {
            await _cargoCustomerService.UpdateCargoCustomerAsync(updateCargoCustomerDTO);
            return RedirectToAction("Index");
        }
    }
}
