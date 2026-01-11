using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CargoDTOs.CargoCompanyDTOs;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoCompanyController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> Index()
        {
            var cargoCompanies = await _cargoCompanyService.GetAllCargoCompaniesAsync();
            return View(cargoCompanies);
        }

        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var value = await _cargoCompanyService.GetCargoCompanyByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDTO);
            return RedirectToAction("Index");
        }
    }
}
