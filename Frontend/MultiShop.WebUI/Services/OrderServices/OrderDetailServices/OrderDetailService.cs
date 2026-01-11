using MultiShop.DTOLayer.OrderDTOs.AddressDTOs;
using MultiShop.DTOLayer.OrderDTOs.OrderDetailDTOs;

namespace MultiShop.WebUI.Services.OrderServices.OrderDetailServices
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly HttpClient _httpClient;

        public OrderDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderDetailAsync(CreateOrderDetailDTO createOrderDetailDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("orderdetails", createOrderDetailDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteOrderDetailAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"orderdetails/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultOrderDetailDTO>> GetAllOrderDetailsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ResultOrderDetailDTO>>("orderdetails");
        }

        public async Task<GetOrderDetailDTO> GetOrderDetailByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetOrderDetailDTO>($"orderdetails/{id}");
        }

        public async Task<List<GetOrderDetailsByOrderIdDTO>> GetOrderDetailsByOrderId(int id)
        {
            return await _httpClient.GetFromJsonAsync<List<GetOrderDetailsByOrderIdDTO>>($"orderdetails/GetOrderDetailsByOrderId/{id}");
        }

        public async Task UpdateOrderDetailAsync(UpdateOrderDetailDTO updateOrderDetailDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"orderdetails", updateOrderDetailDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
