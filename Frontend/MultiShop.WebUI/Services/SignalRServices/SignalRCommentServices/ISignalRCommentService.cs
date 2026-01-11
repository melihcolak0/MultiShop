namespace MultiShop.WebUI.Services.SignalRServices.SignalRCommentServices
{
    public interface ISignalRCommentService
    {
        Task<int> GetTotalCommentCountAsync();
    }
}
