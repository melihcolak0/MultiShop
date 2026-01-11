using MultiShop.DTOLayer.MessageDTOs.UserMessageDTOs;
using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.Services.MessageServices.UserMessageServices
{
    public class UserMessageService : IUserMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly IUserService _userService;

        public UserMessageService(HttpClient httpClient, IUserService userService)
        {
            _httpClient = httpClient;
            _userService = userService;
        }

        public async Task ChangeUserMessageReadingAsync(int id)
        {
            var response = await _httpClient.PutAsync($"usermessage/ChangeUserMessageReading/{id}", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateUserMessageAsync(CreateUserMessageDTO createUserMessageDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("usermessage", createUserMessageDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUserMessageAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"usermessage/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultUserMessageDTO>> GetAllUserMessagesAsync()
        {
            //return await _httpClient.GetFromJsonAsync<List<ResultUserMessageDTO>>("usermessage");

            var messages = await _httpClient.GetFromJsonAsync<List<ResultUserMessageDTO>>("usermessage");

            foreach (var message in messages)
            {
                var sender = await _userService.GetUserInfoById(message.SenderId);
                var receiver = await _userService.GetUserInfoById(message.ReceiverId);

                message.ReceiverName = receiver.Name;
                message.ReceiverSurname = receiver.Surname;
                message.ReceiverEmail = receiver.Email;

                message.SenderName = sender.Name;
                message.SenderSurname = sender.Surname;
                message.SenderEmail = sender.Email;
            }

            return messages;
        }

        public async Task<List<ResultInboxDTO>> GetInboxUserMessagesAsync(string id)
        {
            var inboxMessages = await _httpClient.GetFromJsonAsync<List<ResultInboxDTO>>($"usermessage/GetInboxUserMessagesList?id={id}");     
            
            foreach(var message in inboxMessages)
            {
                var sender = await _userService.GetUserInfoById(message.SenderId);

                message.SenderName = sender.Name;
                message.SenderSurname = sender.Surname;
                message.SenderEmail = sender.Email;
            }

            return inboxMessages;
        }

        public async Task<List<ResultSendboxDTO>> GetSendboxUserMessagesAsync(string id)
        {
            var sendboxMessages = await _httpClient.GetFromJsonAsync<List<ResultSendboxDTO>>($"usermessage/GetSendboxUserMessagesList?id={id}");

            foreach (var message in sendboxMessages)
            {
                var receiver = await _userService.GetUserInfoById(message.ReceiverId);

                message.ReceiverName = receiver.Name;
                message.ReceiverSurname = receiver.Surname;
                message.ReceiverEmail = receiver.Email;
            }

            return sendboxMessages;
        }

        public async Task<GetUserMessageDTO> GetUserMessageByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GetUserMessageDTO>($"usermessage/{id}");
        }

        public async Task UpdateUserMessageAsync(UpdateUserMessageDTO updateUserMessageDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"usermessage", updateUserMessageDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
