using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.MessageServices.UserMessageServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IUserMessageService _userMessageService;

        public MessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userMessageService.GetAllUserMessagesAsync();
            return View(values);
        }       
    }
}
