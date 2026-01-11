namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public interface IMessageStatisticService
    {
        Task<int> GetTotalMessageCount();
        Task<int> GetTotalMessageCountByReceiverIdAsync(string id);
    }
}
