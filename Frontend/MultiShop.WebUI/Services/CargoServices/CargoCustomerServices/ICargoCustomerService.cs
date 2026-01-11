using MultiShop.DTOLayer.CargoDTOs.CargoCustomerDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<List<ResultCargoCustomerDTO>> GetAllCargoCustomersAsync();
        Task CreateCargoCustomerAsync(CreateCargoCustomerDTO createCargoCustomerDTO);
        Task UpdateCargoCustomerAsync(UpdateCargoCustomerDTO updateCargoCustomerDTO);
        Task DeleteCargoCustomerAsync(int id);
        Task<GetCargoCustomerDTO> GetCargoCustomerByIdAsync(int id);
        Task<GetCargoCustomerDTO> GetCargoCustomerByUserIdAsync(string id);
    }
}
