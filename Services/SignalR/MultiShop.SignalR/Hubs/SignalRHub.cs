using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalR.Services;

namespace MultiShop.SignalR.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRService _signalRService;

        public SignalRHub(ISignalRService signalRService)
        {
            _signalRService = signalRService;
        }


    }
}
