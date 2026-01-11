using MultiShop.DTOLayer.CargoDTOs.CargoCustomerDTOs;
using MultiShop.DTOLayer.CargoDTOs.CargoOperationDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoOperationServices
{
    public class CargoOperationService : ICargoOperationService
    {
        private readonly HttpClient _httpClient;

        public CargoOperationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoOperationAsync(CreateCargoOperationDTO createCargoOperationDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("cargooperation", createCargoOperationDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCargoOperationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"cargooperation/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultCargoOperationDTO>> GetAllCargoOperationsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCargoOperationDTO>>("cargooperation");
        }

        public async Task<GetCargoOperationDTO> GetCargoOperationByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GetCargoOperationDTO>($"cargooperation/{id}");
        }

        public async Task UpdateCargoOperationAsync(UpdateCargoOperationDTO updateCargoOperationDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"cargooperation", updateCargoOperationDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
