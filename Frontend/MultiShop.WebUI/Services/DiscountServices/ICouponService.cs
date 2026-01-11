using MultiShop.DTOLayer.DiscountDTOs;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface ICouponService
    {
        Task<GetCouponDetailsByCodeDTO> GetCouponByCode(string code);
        Task InActivateCouponByCodeAsync(string code);

        Task<List<ResultCouponDTO>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDTO createCouponDTO);
        Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO);
        Task DeleteCouponAsync(int id);
        Task<GetCouponDTO> GetCouponByIdAsync(int id);
    }
}
