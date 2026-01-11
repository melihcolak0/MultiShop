using MultiShop.DTOLayer.IdentityDTOs;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserDTO>> GetAllUsersList()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultUserDTO>>("api/users/getalluserslist");
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("api/users/getuserinfo");
        }

        public async Task<GetUserDTO> GetUserInfoById(string userId)
        {
            var response = await _httpClient.GetFromJsonAsync<GetUserDTO>($"api/users/getuserinfobyid?id={userId}");
            return response;
        }
    }
}
