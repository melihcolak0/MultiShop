using MultiShop.DTOLayer.CatalogDTOs.CategoryDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO);
        Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO);
        Task DeleteCategoryAsync(string id);
        Task<GetCategoryDTO> GetCategoryByIdAsync(string id);
        Task<List<ResultCategoryWithProductCountDTO>> GetAllCategoriesWithProductCountAsync();
    }
}
