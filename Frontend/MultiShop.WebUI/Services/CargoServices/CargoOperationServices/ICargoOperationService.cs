using MultiShop.DTOLayer.CargoDTOs.CargoOperationDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoOperationServices
{
    public interface ICargoOperationService
    {
        Task<List<ResultCargoOperationDTO>> GetAllCargoOperationsAsync();
        Task CreateCargoOperationAsync(CreateCargoOperationDTO createCargoOperationDTO);
        Task UpdateCargoOperationAsync(UpdateCargoOperationDTO updateCargoOperationDTO);
        Task DeleteCargoOperationAsync(int id);
        Task<GetCargoOperationDTO> GetCargoOperationByIdAsync(int id);
    }
}
