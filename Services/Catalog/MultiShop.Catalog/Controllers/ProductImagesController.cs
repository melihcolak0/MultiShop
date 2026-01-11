using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImagesList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("GetProductImagesListWithProduct")]
        public async Task<IActionResult> GetProductImagesListWithProduct()
        {
            var values = await _productImageService.GetAllProductImageWithProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _productImageService.GetProductImageByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDTO createProductImageDTO)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDTO);
            return Ok("Yeni ürün resmi başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün resmi başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO updateProductImageDTO)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDTO);
            return Ok("Ürün resmi başarıyla güncellendi!");
        }

        [HttpGet("GetProductImageByProductId/{id}")]
        public async Task<IActionResult> GetProductImageByProductId(string id)
        {
            var value = await _productImageService.GetProductImageByProductIdAsync(id);
            return Ok(value);
        }
    }
}
