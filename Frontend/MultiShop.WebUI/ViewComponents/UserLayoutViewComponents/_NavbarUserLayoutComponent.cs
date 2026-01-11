using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Abstract;

namespace MultiShop.WebUI.ViewComponents.UserLayoutViewComponents
{
    public class _NavbarUserLayoutComponent : ViewComponent
    {
        private readonly IUserService _userService;

        public _NavbarUserLayoutComponent(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userService.GetUserInfo();
            ViewBag.userId = user.Id;
            ViewBag.name = user.Name;
            ViewBag.surname = user.Surname;
            ViewBag.username = user.Username;

            return View();
        }
    }
}
