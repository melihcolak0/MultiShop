using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.AboutDTOs;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAboutsList()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return Ok(values);
        }


        [HttpGet("GetActiveAboutsList")]
        public async Task<IActionResult> GetActiveAboutsList()
        {
            var values = await _aboutService.GetAllActiveAboutsAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var value = await _aboutService.GetAboutByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO createAboutDTO)
        {
            await _aboutService.CreateAboutAsync(createAboutDTO);
            return Ok("Yeni hakkımda bölümü başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("Hakkımda bölümü başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDTO);
            return Ok("Hakkımda bölümü başarıyla güncellendi!");
        }

        [HttpPut("ChangeAboutStatus/{id}")]
        public async Task<IActionResult> ChangeAboutStatus(string id)
        {
            await _aboutService.ChangeAboutStatusAsync(id);
            return Ok("Hakkımda bölümü durumu başarıyla değiştirildi!");
        }
    }
}
