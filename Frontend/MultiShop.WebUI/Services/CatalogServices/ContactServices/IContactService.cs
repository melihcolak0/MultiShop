using MultiShop.DTOLayer.CatalogDTOs.ContactDTOs;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDTO>> GetAllContactAsync();
        Task<List<ResultContactDTO>> GetReadContactsAsync();
        Task CreateContactAsync(CreateContactDTO createContactDTO);
        Task UpdateContactAsync(UpdateContactDTO updateContactDTO);
        Task DeleteContactAsync(string id);
        Task<GetContactDTO> GetContactByIdAsync(string id);
        Task ChangeContactReadingAsync(string id);
    }
}
