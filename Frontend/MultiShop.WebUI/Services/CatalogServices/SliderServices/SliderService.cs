using MultiShop.DTOLayer.CatalogDTOs.SliderDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly HttpClient _httpClient;

        public SliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ChangeSliderStatusAsync(string id)
        {
            var response = await _httpClient.PutAsync($"sliders/ChangeSliderStatus/{id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateSliderAsync(CreateSliderDTO createSliderDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("sliders", createSliderDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSliderAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"sliders/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultSliderDTO>> GetAllActiveSlidersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultSliderDTO>>("sliders/GetActiveSlidersList");
        }

        public async Task<List<ResultSliderDTO>> GetAllSliderAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultSliderDTO>>("sliders");
        }

        public async Task<GetSliderDTO> GetSliderByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetSliderDTO>($"sliders/{id}");
        }

        public async Task UpdateSliderAsync(UpdateSliderDTO updateSliderDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"sliders", updateSliderDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
