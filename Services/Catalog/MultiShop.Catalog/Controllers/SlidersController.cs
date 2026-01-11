using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.SliderDTOs;
using MultiShop.Catalog.Services.SliderServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SlidersController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SlidersController(ISliderService categoryService)
        {
            _sliderService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSlidersList()
        {
            var values = await _sliderService.GetAllSliderAsync();
            return Ok(values);
        }

        [HttpGet("GetActiveSlidersList")]
        public async Task<IActionResult> GetActiveSlidersList()
        {
            var values = await _sliderService.GetAllActiveSlidersAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSliderById(string id)
        {
            var value = await _sliderService.GetSliderByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderDTO createSliderDTO)
        {
            await _sliderService.CreateSliderAsync(createSliderDTO);
            return Ok("Yeni slider başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderService.DeleteSliderAsync(id);
            return Ok("Slider başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDTO updateSliderDTO)
        {
            await _sliderService.UpdateSliderAsync(updateSliderDTO);
            return Ok("Slider başarıyla güncellendi!");
        }

        [HttpPut("ChangeSliderStatus/{id}")]
        public async Task<IActionResult> ChangeSliderStatus(string id)
        {
            await _sliderService.ChangeSliderStatusAsync(id);
            return Ok("Slider durumu başarıyla değiştirildi!");
        }
    }
}
