using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.SliderDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _sliderCollection = database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);
            _mapper = mapper;
        }

        public async Task ChangeSliderStatusAsync(string id)
        {
            var value = await _sliderCollection.Find(x => x.SliderId == id).FirstOrDefaultAsync();
            if (value != null)
            {
                value.Status = !value.Status;
                await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderId == id, value);
            }
        }

        public async Task CreateSliderAsync(CreateSliderDTO createSliderDTO)
        {
            var value = _mapper.Map<Slider>(createSliderDTO);
            await _sliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _sliderCollection.DeleteOneAsync(x => x.SliderId == id);
        }

        public async Task<List<ResultSliderDTO>> GetAllActiveSlidersAsync()
        {
            var values = await _sliderCollection.Find(x => x.Status == true).ToListAsync();
            return _mapper.Map<List<ResultSliderDTO>>(values);
        }

        public async Task<List<ResultSliderDTO>> GetAllSliderAsync()
        {
            var values = await _sliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDTO>>(values);
        }

        public async Task<GetSliderDTO> GetSliderByIdAsync(string id)
        {
            var value = await _sliderCollection.Find(x => x.SliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetSliderDTO>(value);
        }

        public async Task UpdateSliderAsync(UpdateSliderDTO updateSliderDTO)
        {
            var value = _mapper.Map<Slider>(updateSliderDTO);
            await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderId == updateSliderDTO.SliderId, value);
        }
    }
}
