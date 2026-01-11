using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDTO>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync();
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
