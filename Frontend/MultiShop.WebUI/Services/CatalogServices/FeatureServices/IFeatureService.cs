using MultiShop.DTOLayer.CatalogDTOs.FeatureDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
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
