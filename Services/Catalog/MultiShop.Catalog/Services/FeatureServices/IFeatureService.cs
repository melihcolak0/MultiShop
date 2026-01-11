using MultiShop.Catalog.DTOs.FeatureDTOs;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDTO>> GetAllFeatureAsync();
        Task<List<ResultFeatureDTO>> GetAllActiveFeaturesAsync();
        Task CreateFeatureAsync(CreateFeatureDTO createFeatureDTO);
        Task UpdateFeatureAsync(UpdateFeatureDTO updateFeatureDTO);
        Task DeleteFeatureAsync(string id);
        Task<GetFeatureDTO> GetFeatureByIdAsync(string id);
        Task ChangeFeatureStatusAsync(string id);
    }
}
