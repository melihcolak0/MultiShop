namespace MultiShop.WebUI.Services.RapidAPIServices.ChatBotAPIServices
{
    public interface IChatBotAPIService
    {
        Task<string> SendMessageAsync(string message);
    }
}
