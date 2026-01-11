using MultiShop.DTOLayer.CommentDTOs.UserCommentDTOs;

namespace MultiShop.WebUI.Services.CommentServices.UserCommentServices
{
    public interface IUserCommentService
    {
        Task<List<ResultUserCommentDTO>> GetAllUserCommentsAsync();
        Task<List<ResultUserCommentDTO>> GetUserCommentsListByProductIdAsync(string id);
        Task CreateUserCommentAsync(CreateUserCommentDTO createUserCommentDTO);
        Task UpdateUserCommentAsync(UpdateUserCommentDTO updateUserCommentDTO);
        Task DeleteUserCommentAsync(int id);
        Task<GetUserCommentDTO> GetUserCommentByIdAsync(int id);
        Task ChangeUserCommentStatusAsync(int id);
    }
}
