using Humanizer;
using MultiShop.DTOLayer.CatalogDTOs.SpecialOfferDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly HttpClient _httpClient;

        public SpecialOfferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ChangeSpecialOfferStatusAsync(string id)
        {
            var response = await _httpClient.PutAsync($"specialoffers/ChangeSpecialOfferStatus/{id}", null);
            response.EnsureSuccessStatusCode();

            // 2. yol
            //var request = new HttpRequestMessage(HttpMethod.Put, $"specialoffers/ChangeSpecialOfferStatus/{id}");
            //var response = await _httpClient.SendAsync(request);
            //response.EnsureSuccessStatusCode();
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("specialoffers", createSpecialOfferDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"specialoffers/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultSpecialOfferDTO>> GetAllActiveSpecialOffersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDTO>>("specialoffers/GetActiveSpecialOffersList");
        }

        public async Task<List<ResultSpecialOfferDTO>> GetAllSpecialOfferAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDTO>>("specialoffers");
        }

        public async Task<GetSpecialOfferDTO> GetSpecialOfferByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetSpecialOfferDTO>($"specialoffers/{id}");
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"specialoffers", updateSpecialOfferDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
