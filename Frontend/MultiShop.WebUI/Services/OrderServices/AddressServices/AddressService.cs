using MultiShop.DTOLayer.OrderDTOs.AddressDTOs;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public class AddressService : IAddressService
    {
        private readonly HttpClient _httpClient;

        public AddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAddressAsync(CreateAddressDTO createAddressDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("addresses", createAddressDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAddressAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"addresses/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<GetAddressDTO> GetAddressByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetAddressDTO>($"addresses/{id}");
        }

        public async Task<List<ResultAddressDTO>> GetAllAddressesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultAddressDTO>>("addresses");
        }

        public async Task UpdateAddressAsync(UpdateAddressDTO updateAddressDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"addresses", updateAddressDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
