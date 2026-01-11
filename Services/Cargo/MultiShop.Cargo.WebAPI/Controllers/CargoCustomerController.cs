using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DTOLayer.DTOs.CargoCustomerDTOs;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult GetCargoCustomersList()
        {
            var values = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _cargoCustomerService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDTO createCargoCustomerDTO)
        {
            _cargoCustomerService.TInsert(new CargoCustomer
            {
                Name = createCargoCustomerDTO.Name,
                Surname = createCargoCustomerDTO.Surname,
                Phone = createCargoCustomerDTO.Phone,
                Email = createCargoCustomerDTO.Email,
                City = createCargoCustomerDTO.City,
                District = createCargoCustomerDTO.District,
                Address = createCargoCustomerDTO.Address,
                CargoUserId = createCargoCustomerDTO.CargoUserId
            });
            return Ok("Müşteri başarıyla eklendi!");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDTO updateCargoCustomerDTO)
        {
            var value = _cargoCustomerService.TGetById(updateCargoCustomerDTO.CargoCustomerId);
            value.Name = updateCargoCustomerDTO.Name;
            value.Surname = updateCargoCustomerDTO.Surname;
            value.Phone = updateCargoCustomerDTO.Phone;
            value.Email = updateCargoCustomerDTO.Email;
            value.City = updateCargoCustomerDTO.City;
            value.District = updateCargoCustomerDTO.District;
            value.Address = updateCargoCustomerDTO.Address;
            value.CargoUserId = updateCargoCustomerDTO.CargoUserId;
            _cargoCustomerService.TUpdate(value);
            return Ok("Müşteri başarıyla güncellendi!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Müşteri başarıyla silindi!");
        }

        [HttpGet("GetCargoCustomerByUserId")]
        public IActionResult GetCargoCustomerByUserId(string userId)
        {
            var value = _cargoCustomerService.TGetCargoCustomerByUserId(userId);
            return Ok(value);
        }
    }
}
