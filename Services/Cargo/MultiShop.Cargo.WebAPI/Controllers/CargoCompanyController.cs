using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoCompanyDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult GetCargoCompaniesList()
        {
            var values = _cargoCompanyService.TGetAll();            
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            _cargoCompanyService.TInsert(new CargoCompany
            {
                CargoCompanyName = createCargoCompanyDTO.CargoCompanyName
            });
            return Ok("Kargo şirketi başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            var value = _cargoCompanyService.TGetById(updateCargoCompanyDTO.CargoCompanyId);
            value.CargoCompanyName = updateCargoCompanyDTO.CargoCompanyName;           
            _cargoCompanyService.TUpdate(value);
            return Ok("Kargo şirketi başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoCompany(int id)
        {          
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi!");
        }
    }
}
