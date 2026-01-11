using Humanizer;
using MultiShop.DTOLayer.CatalogDTOs.ProductImageDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("productimages", createProductImageDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductImageAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"productimages/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultProductImageDTO>> GetAllProductImageAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductImageDTO>>("productimages");
        }

        public async Task<List<ResultProductImageWithProductDTO>> GetAllProductImageWithProductAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductImageWithProductDTO>>("productimages/GetProductImagesListWithProduct");
        }

        public async Task<GetProductImageDTO> GetProductImageByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetProductImageDTO>($"productimages/{id}");
        }

        public async Task<GetProductImageDTO> GetProductImageByProductIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetProductImageDTO>($"productimages/GetProductImageByProductId/{id}");
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"productimages", updateProductImageDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
