using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDTO);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDTO>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDTO>>(values);
        }

        public async Task<List<ResultProductImageWithProductDTO>> GetAllProductImageWithProductAsync()
        {
            // Tüm ürünler
            var products = await _productCollection.Find(x => true).ToListAsync();

            // Tüm resimler
            var images = await _productImageCollection.Find(x => true).ToListAsync();

            var result = new List<ResultProductImageWithProductDTO>();

            foreach (var img in images)
            {
                var product = products.FirstOrDefault(p => p.ProductId == img.ProductId);

                if (product != null)
                {
                    var dto = new ResultProductImageWithProductDTO
                    {
                        ProductImageId = img.ProductImageId,
                        Image1Url = img.Image1Url,
                        Image2Url = img.Image2Url,
                        Image3Url = img.Image3Url,
                        ProductId = product.ProductId,
                        ProductName = product.ProductName
                    };

                    result.Add(dto);
                }
            }

            return result;
        }

        public async Task<GetProductImageDTO> GetProductImageByIdAsync(string id)
        {
            var value = await _productImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductImageDTO>(value);
        }

        public async Task<GetProductImageDTO> GetProductImageByProductIdAsync(string id)
        {
            var value = await _productImageCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductImageDTO>(value);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDTO);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDTO.ProductImageId, value);
        }
    }
}
