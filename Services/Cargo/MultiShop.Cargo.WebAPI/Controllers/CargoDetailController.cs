using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoDetailDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult GetCargoDetailsList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDTO createCargoDetailDTO)
        {
            _cargoDetailService.TInsert(new CargoDetail
            {
                CargoCompanyId = createCargoDetailDTO.CargoCompanyId,
                Barcode = createCargoDetailDTO.Barcode,
                SenderCustomer = createCargoDetailDTO.SenderCustomer,
                ReceiverCustomer = createCargoDetailDTO.ReceiverCustomer                
            });
            return Ok("Kargo detayı başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDTO updateCargoDetailDTO)
        {
            var value = _cargoDetailService.TGetById(updateCargoDetailDTO.CargoDetailId);
            value.CargoCompanyId = updateCargoDetailDTO.CargoCompanyId;
            value.Barcode = updateCargoDetailDTO.Barcode;
            value.SenderCustomer = updateCargoDetailDTO.SenderCustomer;
            value.ReceiverCustomer = updateCargoDetailDTO.ReceiverCustomer;
            _cargoDetailService.TUpdate(value);
            return Ok("Kargo detayı başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo detayı başarıyla silindi!");
        }
    }
}
