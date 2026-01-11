using MultiShop.DTOLayer.CatalogDTOs.AboutDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly HttpClient _httpClient;

        public AboutService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ChangeAboutStatusAsync(string id)
        {
            var response = await _httpClient.PutAsync($"abouts/ChangeAboutStatus/{id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateAboutAsync(CreateAboutDTO createAboutDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("abouts", createAboutDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAboutAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"abouts/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<GetAboutDTO> GetAboutByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetAboutDTO>($"abouts/{id}");
        }

        public async Task<List<ResultAboutDTO>> GetAllAboutAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultAboutDTO>>("abouts");
        }

        public async Task<List<ResultAboutDTO>> GetAllActiveAboutsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultAboutDTO>>("abouts/GetActiveAboutsList");
        }

        public async Task UpdateAboutAsync(UpdateAboutDTO updateAboutDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"abouts", updateAboutDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
