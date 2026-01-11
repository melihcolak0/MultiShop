using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.FeatureDTOs;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureService _featureService;

        public FeaturesController(IFeatureService categoryService)
        {
            _featureService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeaturesList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return Ok(values);
        }

        [HttpGet("GetActiveFeaturesList")]
        public async Task<IActionResult> GetActiveFeaturesList()
        {
            var values = await _featureService.GetAllActiveFeaturesAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(string id)
        {
            var value = await _featureService.GetFeatureByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            await _featureService.CreateFeatureAsync(createFeatureDTO);
            return Ok("Yeni özellik başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Özellik başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDTO);
            return Ok("Özellik başarıyla güncellendi!");
        }

        [HttpPut("ChangeFeatureStatus/{id}")]
        public async Task<IActionResult> ChangeFeatureStatus(string id)
        {
            await _featureService.ChangeFeatureStatusAsync(id);
            return Ok("Özellik durumu başarıyla değiştirildi!");
        }
    }
}
