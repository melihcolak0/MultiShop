using MultiShop.DTOLayer.CargoDTOs.CargoCompanyDTOs;
using MultiShop.DTOLayer.CargoDTOs.CargoDetailDTOs;
using MultiShop.WebUI.Services.Abstract;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Services.CargoServices.CargoDetailServices
{
    public class CargoDetailService : ICargoDetailService
    {
        private readonly HttpClient _httpClient;
        private readonly IUserService _userService;
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoDetailService(HttpClient httpClient, IUserService userService, ICargoCompanyService cargoCompanyService)
        {
            _httpClient = httpClient;
            _userService = userService;
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task CreateCargoDetailAsync(CreateCargoDetailDTO createCargoDetailDTO)
        {
            var response = await _httpClient.PostAsJsonAsync("cargodetail", createCargoDetailDTO);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCargoDetailAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"cargodetail/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<List<ResultCargoDetailDTO>> GetAllCargoDetailsAsync()
        {
            var cargoDetails = await _httpClient.GetFromJsonAsync<List<ResultCargoDetailDTO>>("cargodetail");

            if (cargoDetails == null || !cargoDetails.Any())
                return cargoDetails;

            foreach (var cargo in cargoDetails)
            {
                // Gönderen
                if (!string.IsNullOrEmpty(cargo.SenderCustomer))
                {
                    var senderUser = await _userService.GetUserInfoById(cargo.SenderCustomer);

                    if (senderUser != null)
                    {
                        cargo.SenderCustomerName = senderUser.Name;
                        cargo.SenderCustomerSurname = senderUser.Surname;
                    }
                }

                // Alıcı
                if (!string.IsNullOrEmpty(cargo.ReceiverCustomer))
                {
                    var receiverUser = await _userService.GetUserInfoById(cargo.ReceiverCustomer);

                    if (receiverUser != null)
                    {
                        cargo.ReceiverCustomerName = receiverUser.Name;
                        cargo.ReceiverCustomerSurname = receiverUser.Surname;
                    }
                }

                var cargoCompany = await _cargoCompanyService.GetCargoCompanyByIdAsync(cargo.CargoCompanyId);

                cargo.CargoCompanyName = cargoCompany.CargoCompanyName;
            }

            return cargoDetails;
        }

        public async Task<GetCargoDetailDTO> GetCargoDetailByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<GetCargoDetailDTO>($"cargodetail/{id}");
        }

        public async Task UpdateCargoDetailAsync(UpdateCargoDetailDTO updateCargoDetailDTO)
        {
            var response = await _httpClient.PutAsJsonAsync($"cargodetail", updateCargoDetailDTO);
            response.EnsureSuccessStatusCode();
        }
    }
}
