
using MultiShop.DTOLayer.CatalogDTOs.AboutDTOs;
using MultiShop.DTOLayer.DiscountDTOs;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class CouponService : ICouponService
    {
        private readonly HttpClient _httpClient;

        public CouponService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCouponAsync(CreateCouponDTO createCouponDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("coupons", createCouponDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCouponAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"coupons/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultCouponDTO>> GetAllCouponAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultCouponDTO>>("coupons");
        }

        public async Task<GetCouponDetailsByCodeDTO> GetCouponByCode(string code)
        {
            return await _httpClient.GetFromJsonAsync<GetCouponDetailsByCodeDTO>($"coupons/GetCouponByCode?code={code}");
        }

        public async Task<GetCouponDTO> GetCouponByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GetCouponDTO>($"coupons/{id}");
        }

        public async Task InActivateCouponByCodeAsync(string code)
        {
            var response = await _httpClient.PutAsync($"coupons/InActivateCouponAsync?code={code}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"coupons", updateCouponDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
