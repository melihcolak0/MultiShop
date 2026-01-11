using MultiShop.DTOLayer.OrderDTOs.OrderDTOs;

namespace MultiShop.WebUI.Services.OrderServices.OrderServices
{
    public interface IOrderService
    {
        Task<List<ResultOrderWithUserInfosDTO>> GetAllOrdersAsync();
        Task CreateOrderAsync(CreateOrderDTO createOrderDTO);
        Task UpdateOrderAsync(UpdateOrderDTO updateOrderDTO);
        Task DeleteOrderAsync(string id);
        Task<GetOrderDTO> GetOrderByIdAsync(string id);
        Task<int> CreateOrderReturnIdAsync(CreateOrderDTO createOrderDTO);
        Task<List<ResultOrderByUserIdDTO>> GetOrdersByUserIdAsync(string id);
    }
}
