using MultiShop.DTOLayer.CargoDTOs.CargoCompanyDTOs;

namespace MultiShop.WebUI.Services.CargoServices.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoCompanyDTO>> GetAllCargoCompaniesAsync();
        Task CreateCargoCompanyAsync(CreateCargoCompanyDTO createCargoCompanyDTO);
        Task UpdateCargoCompanyAsync(UpdateCargoCompanyDTO updateCargoCompanyDTO);
        Task DeleteCargoCompanyAsync(int id);
        Task<GetCargoCompanyDTO> GetCargoCompanyByIdAsync(int id);
    }
}
