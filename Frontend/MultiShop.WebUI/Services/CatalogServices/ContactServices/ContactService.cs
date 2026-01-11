using MultiShop.DTOLayer.CatalogDTOs.ContactDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ChangeContactReadingAsync(string id)
        {
            var response = await _httpClient.PutAsync($"contacts/ChangeContactReading/{id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateContactAsync(CreateContactDTO createContactDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("contacts", createContactDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteContactAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"contacts/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultContactDTO>> GetAllContactAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultContactDTO>>("contacts");
        }

        public async Task<GetContactDTO> GetContactByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetContactDTO>($"contacts/{id}");
        }

        public async Task<List<ResultContactDTO>> GetReadContactsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultContactDTO>>("contacts/GetReadContactsList");
        }

        public async Task UpdateContactAsync(UpdateContactDTO updateContactDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"contacts", updateContactDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
