using MultiShop.Catalog.DTOs.ContactDTOs;

namespace MultiShop.Catalog.Services.ContactServices
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
