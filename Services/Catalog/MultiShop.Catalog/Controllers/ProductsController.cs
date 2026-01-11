using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsList()
        {
            var values = await _productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("GetProductsListWithCategory")]
        public async Task<IActionResult> GetProductsListWithCategory()
        {
            var values = await _productService.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _productService.GetProductByIdAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO createProductDTO)
        {
            await _productService.CreateProductAsync(createProductDTO);
            return Ok("Yeni ürün başarıyla eklendi!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateProductDTO)
        {
            await _productService.UpdateProductAsync(updateProductDTO);
            return Ok("Ürün başarıyla güncellendi!");
        }

        [HttpGet("GetPopularProducts")]
        public async Task<IActionResult> GetPopularProducts()
        {
            var values = await _productService.GetPopularProductsAsync();
            return Ok(values);
        }

        [HttpPost("GetProductsByFilter")]
        public async Task<IActionResult> GetProductsByFilter(ResultProductByFilterDTO filter)
        {
            var result = await _productService.GetProductsByFilterAsync(filter);
            return Ok(result);
        }

        [HttpGet("GetMinProductPrice")]
        public async Task<IActionResult> GetMinProductPrice()
        {
            var minPrice = await _productService.GetMinProductPrice();
            return Ok(minPrice);
        }

        [HttpGet("GetMaxProductPrice")]
        public async Task<IActionResult> GetMaxProductPrice()
        {
            var maxPrice = await _productService.GetMaxProductPrice();
            return Ok(maxPrice);
        }

        [HttpGet("GetProductCountByCategory")]
        public async Task<IActionResult> GetProductCountByCategory()
        {
            var values = await _productService.GetProductCountByCategoryAsync();
            return Ok(values);
        }
    }
}
