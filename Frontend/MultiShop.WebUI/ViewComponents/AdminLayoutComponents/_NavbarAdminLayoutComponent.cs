using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.AdminLayoutComponents
{
    public class _NavbarAdminLayoutComponent : ViewComponent
    {
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly IUserService _userService;

        public _NavbarAdminLayoutComponent(ICommentStatisticService commentStatisticService, IMessageStatisticService messageStatisticService, IUserService userService)
        {
            _commentStatisticService = commentStatisticService;
            _messageStatisticService = messageStatisticService;
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            ViewBag.messageCountByReceiverId = await _messageStatisticService.GetTotalMessageCountByReceiverIdAsync(user.Id);
            ViewBag.commentCount = await _commentStatisticService.GetTotalCommentCountAsync();
            return View();
        }
    }
}
