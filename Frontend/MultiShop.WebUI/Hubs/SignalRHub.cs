using Microsoft.AspNetCore.SignalR;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.SignalRServices.SignalRCommentServices;
using MultiShop.WebUI.Services.SignalRServices.SignalRMessageServices;

namespace MultiShop.WebUI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRMessageService _signalRMessageService;
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly IUserService _userService;

        public SignalRHub(ISignalRMessageService signalRMessageService, IUserService userService, ISignalRCommentService signalRCommentService)
        {
            _signalRMessageService = signalRMessageService;
            _userService = userService;
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatistics()
        {
            var user = await _userService.GetUserInfo();

            var totalMessageCount =
                await _signalRMessageService.GetTotalMessageCountByReceiverIdAsync(user.Id);

            var totalCommentCount =
                await _signalRCommentService.GetTotalCommentCountAsync();

            //await Clients.Caller.SendAsync("ReceiveTotalMessageCount", totalMessageCount);
            //await Clients.All.SendAsync("ReceiveTotalCommentCount", totalCommentCount);

            await Clients.Caller.SendAsync("ReceiveStatistics", new
            {
                messageCount = totalMessageCount,
                commentCount = totalCommentCount
            });
        }
    }
}
