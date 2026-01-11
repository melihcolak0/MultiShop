using MultiShop.Catalog.DTOs.AboutDTOs;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAboutDTO>> GetAllAboutAsync();
        Task<List<ResultAboutDTO>> GetAllActiveAboutsAsync();
        Task CreateAboutAsync(CreateAboutDTO createAboutDTO);
        Task UpdateAboutAsync(UpdateAboutDTO updateAboutDTO);
        Task DeleteAboutAsync(string id);
        Task<GetAboutDTO> GetAboutByIdAsync(string id);
        Task ChangeAboutStatusAsync(string id);
    }
}
