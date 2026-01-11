using MultiShop.DTOLayer.CatalogDTOs.FeatureDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ChangeFeatureStatusAsync(string id)
        {
            var response = await _httpClient.PutAsync($"features/ChangeFeatureStatus/{id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateFeatureAsync(CreateFeatureDTO createFeatureDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("features", createFeatureDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteFeatureAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"features/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultFeatureDTO>> GetAllActiveFeaturesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultFeatureDTO>>("features/GetActiveFeaturesList");
        }

        public async Task<List<ResultFeatureDTO>> GetAllFeatureAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultFeatureDTO>>("features");
        }

        public async Task<GetFeatureDTO> GetFeatureByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetFeatureDTO>($"features/{id}");
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"features", updateFeatureDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
