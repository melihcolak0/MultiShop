using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ContactDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task ChangeContactReadingAsync(string id)
        {
            var value = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            if (value != null)
            {
                value.IsRead = !value.IsRead;
                await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == id, value);
            }
        }

        public async Task CreateContactAsync(CreateContactDTO createContactDTO)
        {
            var value = _mapper.Map<Contact>(createContactDTO);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<List<ResultContactDTO>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDTO>>(values);
        }

        public async Task<GetContactDTO> GetContactByIdAsync(string id)
        {
            var value = await _contactCollection.Find(x => x.ContactId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetContactDTO>(value);
        }

        public async Task<List<ResultContactDTO>> GetReadContactsAsync()
        {
            var values = await _contactCollection.Find(x => x.IsRead == true).ToListAsync();
            return _mapper.Map<List<ResultContactDTO>>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDTO updateContactDTO)
        {
            var value = _mapper.Map<Contact>(updateContactDTO);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactId == updateContactDTO.ContactId, value);
        }
    }
}
