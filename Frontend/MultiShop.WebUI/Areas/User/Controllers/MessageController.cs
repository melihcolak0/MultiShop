using Microsoft.AspNetCore.Mvc;
using MultiShop.DTOLayer.IdentityDTOs;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.MessageServices.UserMessageServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IUserMessageService _userMessageService;
        private readonly IUserService _userService;

        public MessageController(IUserMessageService userMessageService, IUserService userService)
        {
            _userMessageService = userMessageService;
            _userService = userService;            
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfo();
            var inboxMessages = await _userMessageService.GetInboxUserMessagesAsync(user.Id);
            return View(inboxMessages);
        }

        public async Task<IActionResult> Sendbox()
        {
            var user = await _userService.GetUserInfo();
            var sendboxMessages = await _userMessageService.GetSendboxUserMessagesAsync(user.Id);
            return View(sendboxMessages);
        }

        public async Task<IActionResult> ChangeUserMessageReading(int id)
        {
            await _userMessageService.ChangeUserMessageReadingAsync(id);
            return RedirectToAction("Inbox", "Message");
        }
    }
}
