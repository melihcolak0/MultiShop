namespace MultiShop.SignalR.Services
{
    public interface ISignalRService
    {
        Task<int> GetTotalMessageCountByReceiverIdAsync(string id);
        Task<int> GetTotalCommentCountAsync();
    }
}
