using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("productdetails", createProductDetailDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"productdetails/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDetailDTO>>("productdetails");
        }

        public async Task<List<ResultProductDetailWithProductDTO>> GetAllProductDetailWithProductAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDetailWithProductDTO>>("productdetails/GetProductDetailsListWithProduct");
        }

        public async Task<GetProductDetailDTO> GetProductDetailByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetProductDetailDTO>($"productdetails/{id}");
        }

        public async Task<GetProductDetailDTO> GetProductDetailByProductIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetProductDetailDTO>($"productdetails/GetProductDetailByProductId/{id}");
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"productdetails", updateProductDetailDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
