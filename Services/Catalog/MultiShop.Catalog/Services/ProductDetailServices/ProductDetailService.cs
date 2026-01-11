using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDTO)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDTO);
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDTO>>(values);
        }

        public async Task<List<ResultProductDetailWithProductDTO>> GetAllProductDetailWithProductAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            var details = await _productDetailCollection.Find(x => true).ToListAsync();
            var result = new List<ResultProductDetailWithProductDTO>();

            foreach (var detail in details)
            {
                var product = products.FirstOrDefault(p => p.ProductId == detail.ProductId);

                if (product != null)
                {
                    var dto = new ResultProductDetailWithProductDTO
                    {
                        ProductDetailId = detail.ProductDetailId,                        
                        ProductId = detail.ProductId,
                        ProductName = product.ProductName,
                        ProductDescription = detail.ProductDescription,
                        ProductInfo  = detail.ProductInfo
                    };

                    result.Add(dto);
                }
            }

            return result;
        }

        public async Task<GetProductDetailDTO> GetProductDetailByIdAsync(string id)
        {
            var value = await _productDetailCollection.Find(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductDetailDTO>(value);
        }

        public async Task<GetProductDetailDTO> GetProductDetailByProductIdAsync(string id)
        {
            var value = await _productDetailCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductDetailDTO>(value);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDTO)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDTO);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDTO.ProductDetailId, value);
        }
    }
}
