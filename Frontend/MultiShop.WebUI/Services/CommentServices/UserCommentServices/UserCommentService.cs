using MultiShop.DTOLayer.CommentDTOs.UserCommentDTOs;

namespace MultiShop.WebUI.Services.CommentServices.UserCommentServices
{
    public class UserCommentService : IUserCommentService
    {
        private readonly HttpClient _httpClient;

        public UserCommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task ChangeUserCommentStatusAsync(int id)
        {
            var response = await _httpClient.PutAsync($"usercomments/ChangeUserCommentStatus/{id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateUserCommentAsync(CreateUserCommentDTO createUserCommentDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("usercomments", createUserCommentDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserCommentAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"usercomments/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultUserCommentDTO>> GetAllUserCommentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultUserCommentDTO>>("usercomments");
        }

        public async Task<GetUserCommentDTO> GetUserCommentByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GetUserCommentDTO>($"usercomments/{id}");
        }

        public async Task<List<ResultUserCommentDTO>> GetUserCommentsListByProductIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultUserCommentDTO>>($"usercomments/GetUserCommentsListByProductId/{id}");
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDTO updateUserCommentDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"usercomments", updateUserCommentDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
