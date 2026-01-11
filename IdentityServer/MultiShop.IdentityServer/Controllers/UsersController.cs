using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.IdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
       
        [HttpGet("getuserinfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userClaims = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaims.Value);

            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email
            });
        }

        [HttpGet("getuserinfobyid")]
        public async Task<IActionResult> GetUserInfoById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest("UserId boş olamaz");

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound("Kullanıcı bulunamadı");

            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email
            });
        }

        [HttpGet("getalluserslist")]
        public async Task<IActionResult> GetAllUsersList()
        {
            var users = await _userManager.Users.ToListAsync();
            
            if (users == null)
                return NotFound("Kullanıcılar bulunamadı");

            return Ok(users);
        }
    }
}
