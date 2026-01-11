using MultiShop.DTOLayer.IdentityDTOs;
using MultiShop.WebUI.Models;

namespace MultiShop.WebUI.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
        Task<GetUserDTO> GetUserInfoById(string userId);
        Task<List<ResultUserDTO>> GetAllUsersList();
    }
}
