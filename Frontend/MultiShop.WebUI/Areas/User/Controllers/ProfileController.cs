using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userService.GetUserInfo();

            ViewBag.name = user.Name;
            ViewBag.surname = user.Surname;
            ViewBag.email = user.Email;
            ViewBag.username = user.Username;
            ViewBag.phone = "+90 123 456 78 90";

            return View();
        }
    }
}
