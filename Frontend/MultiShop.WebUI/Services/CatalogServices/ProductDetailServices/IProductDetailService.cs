using MultiShop.DTOLayer.CatalogDTOs.ProductDetailDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync();
        Task<List<ResultProductDetailWithProductDTO>> GetAllProductDetailWithProductAsync();
        Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO);
        Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO);
        Task DeleteProductDetailAsync(string id);
        Task<GetProductDetailDTO> GetProductDetailByIdAsync(string id);
        Task<GetProductDetailDTO> GetProductDetailByProductIdAsync(string id);
    }
}
