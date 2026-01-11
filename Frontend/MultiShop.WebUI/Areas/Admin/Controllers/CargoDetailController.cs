using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DTOLayer.CargoDTOs.CargoDetailDTOs;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using MultiShop.WebUI.Services.CargoServices.CargoDetailServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoDetailController : Controller
    {
        private readonly ICargoDetailService _cargoDetailService;
        private readonly IUserService _userService;
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoDetailController(ICargoDetailService cargoDetailService, IUserService userService, ICargoCompanyService cargoCompanyService)
        {
            _cargoDetailService = cargoDetailService;
            _userService = userService;
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> Index()
        {
            var cargoDetails = await _cargoDetailService.GetAllCargoDetailsAsync();
            return View(cargoDetails);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCargoDetail()
        {
            var values = await _userService.GetAllUsersList();

            List<SelectListItem> users = (from x in values
                                          select new SelectListItem
                                          {
                                              Text = x.name + " " + x.surname,
                                              Value = x.id
                                          }).ToList();

            ViewBag.Users = users;

            var values2 = await _cargoCompanyService.GetAllCargoCompaniesAsync();

            List<SelectListItem> cargoCompaines = (from x in values2
                                          select new SelectListItem
                                          {
                                              Text = x.CargoCompanyName,
                                              Value = x.CargoCompanyId.ToString()
                                          }).ToList();

            ViewBag.CargoCompaines = cargoCompaines;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail(CreateCargoDetailDTO createCargoDetailDTO)
        {
            await _cargoDetailService.CreateCargoDetailAsync(createCargoDetailDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCargoDetail(int id)
        {
            await _cargoDetailService.DeleteCargoDetailAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoDetail(int id)
        {
            var values = await _userService.GetAllUsersList();

            List<SelectListItem> users = (from x in values
                                          select new SelectListItem
                                          {
                                              Text = x.name + " " + x.surname,
                                              Value = x.id
                                          }).ToList();

            ViewBag.Users = users;

            var values2 = await _cargoCompanyService.GetAllCargoCompaniesAsync();

            List<SelectListItem> cargoCompaines = (from x in values2
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CargoCompanyName,
                                                       Value = x.CargoCompanyId.ToString()
                                                   }).ToList();

            ViewBag.CargoCompaines = cargoCompaines;

            var value = await _cargoDetailService.GetCargoDetailByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoDetail(UpdateCargoDetailDTO updateCargoDetailDTO)
        {
            await _cargoDetailService.UpdateCargoDetailAsync(updateCargoDetailDTO);
            return RedirectToAction("Index");
        }
    }
}
