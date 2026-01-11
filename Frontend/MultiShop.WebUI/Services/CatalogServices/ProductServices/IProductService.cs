using MultiShop.DTOLayer.CatalogDTOs.ProductDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDTO>> GetAllProductsWithCategory();
        Task CreateProductAsync(CreateProductDTO createProductDTO);
        Task UpdateProductAsync(UpdateProductDTO updateProductDTO);
        Task DeleteProductAsync(string id);
        Task<GetProductDTO> GetProductByIdAsync(string id);
        Task<List<ResultProductDTO>> GetPopularProductsAsync(int count = 10);
        Task<PagedResult<ResultProductDTO>> GetProductsByFilterAsync(ResultProductByFilterDTO filter);
        Task<decimal> GetMinProductPrice();
        Task<decimal> GetMaxProductPrice();
        Task<List<CategoryProductCountDTO>> GetProductCountByCategoryAsync();

    }
}
