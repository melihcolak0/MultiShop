using MultiShop.Catalog.DTOs.SpecialOfferDTOs;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDTO>> GetAllSpecialOfferAsync();
        Task<List<ResultSpecialOfferDTO>> GetAllActiveSpecialOffersAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOfferDTO createSpecialOfferDTO);
        Task UpdateSpecialOfferAsync(UpdateSpecialOfferDTO updateSpecialOfferDTO);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetSpecialOfferDTO> GetSpecialOfferByIdAsync(string id);
        Task ChangeSpecialOfferStatusAsync(string id);
    }
}
