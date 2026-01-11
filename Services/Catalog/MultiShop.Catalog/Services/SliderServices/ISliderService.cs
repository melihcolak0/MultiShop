using MultiShop.Catalog.DTOs.SliderDTOs;

namespace MultiShop.Catalog.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDTO>> GetAllSliderAsync();
        Task<List<ResultSliderDTO>> GetAllActiveSlidersAsync();
        Task CreateSliderAsync(CreateSliderDTO createSliderDTO);
        Task UpdateSliderAsync(UpdateSliderDTO updateSliderDTO);
        Task DeleteSliderAsync(string id);
        Task<GetSliderDTO> GetSliderByIdAsync(string id);
        Task ChangeSliderStatusAsync(string id);
    }
}
