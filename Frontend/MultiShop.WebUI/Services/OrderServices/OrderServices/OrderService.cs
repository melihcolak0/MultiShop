using MultiShop.DTOLayer.OrderDTOs.AddressDTOs;
using MultiShop.DTOLayer.OrderDTOs.OrderDTOs;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Services.OrderServices.OrderServices
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly IUserService _userService;

        public OrderService(HttpClient httpClient, IUserService userService)
        {
            _httpClient = httpClient;
            _userService = userService;
        }

        public async Task CreateOrderAsync(CreateOrderDTO createOrderDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("orders", createOrderDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task<int> CreateOrderReturnIdAsync(CreateOrderDTO createOrderDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("orders/CreateOrderReturnId", createOrderDTO);
            response.EnsureSuccessStatusCode();

            var orderId = await response.Content.ReadFromJsonAsync<int>();
            return orderId;
        }

        public async Task DeleteOrderAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"orders/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultOrderWithUserInfosDTO>> GetAllOrdersAsync()
        {
            // Siparişleri al
            var orders = await _httpClient
                .GetFromJsonAsync<List<ResultOrderWithUserInfosDTO>>("orders");

            if (orders == null || !orders.Any())
                return orders;

            // Her sipariş için User Service çağır
            foreach (var order in orders)
            {
                if (string.IsNullOrEmpty(order.UserId))
                    continue;

                var user = await _userService.GetUserInfoById(order.UserId);

                if (user != null)
                {
                    order.UserName = user.Name;
                    order.UserSurname = user.Surname;
                }
            }

            return orders;

            //return await _httpClient.GetFromJsonAsync<List<ResultOrderDTO>>("orders");
        }

        public async Task<GetOrderDTO> GetOrderByIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<GetOrderDTO>($"orders/{id}");
        }

        public async Task<List<ResultOrderByUserIdDTO>> GetOrdersByUserIdAsync(string id)
        {
            return await _httpClient.GetFromJsonAsync<List<ResultOrderByUserIdDTO>>($"orders/GetOrdersListByUserId?id={id}");
        }

        public async Task UpdateOrderAsync(UpdateOrderDTO updateOrderDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"orders", updateOrderDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
