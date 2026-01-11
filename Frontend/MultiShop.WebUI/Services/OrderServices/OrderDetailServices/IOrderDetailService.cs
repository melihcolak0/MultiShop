using MultiShop.DTOLayer.OrderDTOs.OrderDetailDTOs;

namespace MultiShop.WebUI.Services.OrderServices.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<List<ResultOrderDetailDTO>> GetAllOrderDetailsAsync();
        Task CreateOrderDetailAsync(CreateOrderDetailDTO createOrderDetailDTO);
        Task UpdateOrderDetailAsync(UpdateOrderDetailDTO updateOrderDetailDTO);
        Task DeleteOrderDetailAsync(string id);
        Task<GetOrderDetailDTO> GetOrderDetailByIdAsync(string id);
        Task<List<GetOrderDetailsByOrderIdDTO>> GetOrderDetailsByOrderId(int id);
    }
}
