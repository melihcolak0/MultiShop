namespace MultiShop.WebUI.Services.StatisticServices.UserStatisticsServices
{
    public interface IUserStatisticsService
    {
        Task<int> GetUserCountAsync();
    }
}
