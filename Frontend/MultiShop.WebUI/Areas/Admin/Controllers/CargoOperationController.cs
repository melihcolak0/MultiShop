using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.CargoDTOs.CargoOperationDTOs;
using MultiShop.WebUI.Services.CargoServices.CargoOperationServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoOperationController : Controller
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        public async Task<IActionResult> Index()
        {
            var cargoOperations = await _cargoOperationService.GetAllCargoOperationsAsync();
            return View(cargoOperations);
        }

        [HttpGet]
        public IActionResult CreateCargoOperation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation(CreateCargoOperationDTO createCargoOperationDTO)
        {
            createCargoOperationDTO.OperationDate = DateTime.Now;

            await _cargoOperationService.CreateCargoOperationAsync(createCargoOperationDTO);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCargoOperation(int id)
        {
            await _cargoOperationService.DeleteCargoOperationAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoOperation(int id)
        {
            var value = await _cargoOperationService.GetCargoOperationByIdAsync(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoOperation(UpdateCargoOperationDTO updateCargoOperationDTO)
        {
            await _cargoOperationService.UpdateCargoOperationAsync(updateCargoOperationDTO);
            return RedirectToAction("Index");
        }
    }
}
