using Humanizer;
using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("products", createProductDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteProductAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultProductDTO>> GetAllProductAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDTO>>("products");
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetAllProductsWithCategory()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDTO>>("products/GetProductsListWithCategory");
        }

        public async Task<decimal> GetMaxProductPrice()
        {
            return await _httpClient.GetFromJsonAsync<decimal>("products/GetMaxProductPrice");
        }

        public async Task<decimal> GetMinProductPrice()
        {
            return await _httpClient.GetFromJsonAsync<decimal>("products/GetMinProductPrice");
        }

        public async Task<List<ResultProductDTO>> GetPopularProductsAsync(int count = 10)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultProductDTO>>("products/GetPopularProducts");
        }

        public async Task<GetProductDTO> GetProductByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetProductDTO>($"products/{id}");
        }

        public async Task<List<CategoryProductCountDTO>> GetProductCountByCategoryAsync()
        {
            var response = await _httpClient.GetAsync("products/GetProductCountByCategory");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<CategoryProductCountDTO>>();
        }

        public async Task<PagedResult<ResultProductDTO>> GetProductsByFilterAsync(ResultProductByFilterDTO filter)
        {
            var response = await _httpClient.PostAsJsonAsync("products/GetProductsByFilter", filter);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<PagedResult<ResultProductDTO>>();
            return result!;
        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"products", updateProductDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
