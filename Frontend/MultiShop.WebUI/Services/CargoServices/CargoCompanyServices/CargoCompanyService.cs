using MultiShop.DTOLayer.CargoDTOs.CargoCompanyDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public class CargoCompanyService : ICargoCompanyService
    {
        private readonly HttpClient _httpClient;

        public CargoCompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("cargocompany", createCargoCompanyDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"cargocompany/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultCargoCompanyDTO>> GetAllCargoCompaniesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCargoCompanyDTO>>("cargocompany");
        }

        public async Task<GetCargoCompanyDTO> GetCargoCompanyByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GetCargoCompanyDTO>($"cargocompany/{id}");
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"cargocompany", updateCargoCompanyDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
