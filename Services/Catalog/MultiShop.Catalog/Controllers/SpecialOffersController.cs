using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.SpecialOfferDTOs;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOffersController(ISpecialOfferService categoryService)
        {
            _specialOfferService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSpecialOffersList()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }

        [HttpGet("GetActiveSpecialOffersList")]
        public async Task<IActionResult> GetActiveSpecialOffersList()
        {
            var values = await _specialOfferService.GetAllActiveSpecialOffersAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialOfferById(string id)
        {
            var value = await _specialOfferService.GetSpecialOfferByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDTO);
            return Ok("Yeni özel teklif başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel teklif başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDTO);
            return Ok("Özel teklif başarıyla güncellendi!");
        }

        [HttpPut("ChangeSpecialOfferStatus/{id}")]
        public async Task<IActionResult> ChangeSpecialOfferStatus(string id)
        {
            await _specialOfferService.ChangeSpecialOfferStatusAsync(id);
            return Ok("Özel teklif durumu başarıyla değiştirildi!");
        }
    }
}
