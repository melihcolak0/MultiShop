namespace MultiShop.WebUI.Services.SignalRServices.SignalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverIdAsync(string id);
    }
}
