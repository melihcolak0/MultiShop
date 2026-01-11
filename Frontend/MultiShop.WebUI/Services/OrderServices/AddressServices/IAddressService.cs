using MultiShop.DTOLayer.OrderDTOs.AddressDTOs;

namespace MultiShop.WebUI.Services.OrderServices.AddressServices
{
    public interface IAddressService
    {
        Task<List<ResultAddressDTO>> GetAllAddressesAsync();
        Task CreateAddressAsync(CreateAddressDTO createAddressDTO);
        Task UpdateAddressAsync(UpdateAddressDTO updateAddressDTO);
        Task DeleteAddressAsync(string id);
        Task<GetAddressDTO> GetAddressByIdAsync(string id);
    }
}
