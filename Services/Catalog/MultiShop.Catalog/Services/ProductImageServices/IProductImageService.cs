using MultiShop.Catalog.DTOs.ProductImageDTOs;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDTO>> GetAllProductImageAsync();
        Task<List<ResultProductImageWithProductDTO>> GetAllProductImageWithProductAsync();
        Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO);
        Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO);
        Task DeleteProductImageAsync(string id);
        Task<GetProductImageDTO> GetProductImageByIdAsync(string id);
        Task<GetProductImageDTO> GetProductImageByProductIdAsync(string id);
    }
}
