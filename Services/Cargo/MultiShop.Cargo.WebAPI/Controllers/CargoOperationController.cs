using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoOperationDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult GetCargoOperationsList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDTO createCargoOperationDTO)
        {
            _cargoOperationService.TInsert(new CargoOperation
            {
                Barcode = createCargoOperationDTO.Barcode,
                Description = createCargoOperationDTO.Description,
                OperationDate = createCargoOperationDTO.OperationDate
            });
            return Ok("Kargo işlemi başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDTO updateCargoOperationDTO)
        {
            var value = _cargoOperationService.TGetById(updateCargoOperationDTO.CargoOperationId);
            value.Barcode = updateCargoOperationDTO.Barcode;
            value.Description = updateCargoOperationDTO.Description;
            value.OperationDate = updateCargoOperationDTO.OperationDate;
            _cargoOperationService.TUpdate(value);
            return Ok("Kargo işlemi başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo işlemi başarıyla silindi!");
        }
    }
}
