using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;
using System.Net.Http;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCategoryDTO>>("categories");
        }

        public async Task<GetCategoryDTO> GetCategoryByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetCategoryDTO>($"categories/{id}");
        }

        public async Task CreateCategoryAsync(CreateCategoryDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("categories", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"categories", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCategoryAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"categories/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultCategoryWithProductCountDTO>> GetAllCategoriesWithProductCountAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCategoryWithProductCountDTO>>("categories/GetCategoriesListWithProductCount");
        }
    }
}


//private readonly HttpClient _httpClient;

//public CategoryService(HttpClient httpClient)
//{
//    _httpClient = httpClient;
//}

//public async Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
//{
//    await _httpClient.PostAsJsonAsync("categories", createCategoryDTO);
//}

//public async Task DeleteCategoryAsync(string id)
//{
//    await _httpClient.DeleteAsync($"categories/{id}");
//}

//public Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
//{
//    var values =  _httpClient.GetFromJsonAsync<List<ResultCategoryDTO>>("categories");
//    return values;
//}

//public Task<GetCategoryDTO> GetCategoryByIdAsync(string id)
//{ 
//    var value = _httpClient.GetFromJsonAsync<GetCategoryDTO>($"categories/{id}");
//    return value;
//}

//public async Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
//{
//    await _httpClient.PutAsJsonAsync("categories", updateCategoryDTO);
//}