using MultiShop.Discount.DTOs;

namespace MultiShop.Discount.Services
{
    public interface ICouponService
    {
        Task<List<ResultCouponDTO>> GetAllCouponAsync();
        Task CreateCouponAsync(CreateCouponDTO createCouponDTO);
        Task UpdateCouponAsync(UpdateCouponDTO updateCouponDTO);
        Task DeleteCouponAsync(string id);
        Task<GetCouponDTO> GetCouponByIdAsync(string id);
        Task<GetCouponDTO> GetCouponByCodeAsync(string code);
        Task InActivateCouponByCodeAsync(string code);
        Task<int> GetCouponCount();
    }
}
