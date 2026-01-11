using MultiShop.DTOLayer.CargoDTOs.CargoCompanyDTOs;
using MultiShop.DTOLayer.CargoDTOs.CargoCustomerDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCargoCustomerAsync(CreateCargoCustomerDTO createCargoCustomerDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("cargocustomer", createCargoCustomerDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCargoCustomerAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"cargocustomer/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultCargoCustomerDTO>> GetAllCargoCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCargoCustomerDTO>>("cargocustomer");
        }

        public async Task<GetCargoCustomerDTO> GetCargoCustomerByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GetCargoCustomerDTO>($"cargocustomer/{id}");
        }

        public async Task<GetCargoCustomerDTO> GetCargoCustomerByUserIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetCargoCustomerDTO>($"cargocustomer/GetCargoCustomerByUserId?userId={id}");
        }

        public async Task UpdateCargoCustomerAsync(UpdateCargoCustomerDTO updateCargoCustomerDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"cargocustomer", updateCargoCustomerDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
