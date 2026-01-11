using MultiShop.Message.DTOs.UserMessageDTOs;

namespace MultiShop.Message.Services.UserMessageServices
{
    public interface IUserMessageService
    {
        Task<List<ResultUserMessageDTO>> GetAllUserMessagesAsync();
        Task<List<ResultInboxDTO>> GetInboxUserMessagesAsync(string id);
        Task<List<ResultSendboxDTO>> GetSendboxUserMessagesAsync(string id);
        Task CreateUserMessageAsync(CreateUserMessageDTO createUserMessageDTO);
        Task UpdateUserMessageAsync(UpdateUserMessageDTO updateUserMessageDTO);
        Task DeleteUserMessageAsync(int id);
        Task<GetUserMessageDTO> GetUserMessageByIdAsync(int id);
        Task ChangeUserMessageReadingAsync(int id);
        Task<int> GetTotalMessageCountAsync();
        Task<int> GetTotalMessageCountByReceiverIdAsync(string id);
    }
}
