using MultiShop.DTOLayer.IdentityDTOs;

namespace MultiShop.WebUI.Services.Abstract
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDTO signInDTO);
        Task<bool> GetRefreshToken();
        Task SignOut();
    }
}
