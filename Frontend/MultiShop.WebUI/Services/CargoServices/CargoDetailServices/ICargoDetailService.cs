using MultiShop.DTOLayer.CargoDTOs.CargoDetailDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoDetailServices
{
    public interface ICargoDetailService
    {
        Task<List<ResultCargoDetailDTO>> GetAllCargoDetailsAsync();
        Task CreateCargoDetailAsync(CreateCargoDetailDTO createCargoDetailDTO);
        Task UpdateCargoDetailAsync(UpdateCargoDetailDTO updateCargoDetailDTO);
        Task DeleteCargoDetailAsync(int id);
        Task<GetCargoDetailDTO> GetCargoDetailByIdAsync(int id);
    }
}
