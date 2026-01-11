using System.Security.Claims;

namespace MultiShop.WebUI.Services
{
    public class LogInService : ILogInService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogInService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId => _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
