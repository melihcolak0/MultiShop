using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var value = _mapper.Map<Product>(createProductDTO);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDTO>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDTO>>(values);
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategoryAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();

            var categories = await _categoryCollection.Find(x => true).ToListAsync();

            var result = new List<ResultProductWithCategoryDTO>();

            foreach (var product in products)
            {
                var dto = _mapper.Map<ResultProductWithCategoryDTO>(product);

                var category = categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);

                dto.CategoryName = category?.CategoryName;

                result.Add(dto);
            }

            return result;
        }

        public async Task<decimal> GetMaxProductPrice()
        {
            // MongoDB'de ProductPrice alanına göre sırala ve ilkini al
            var maxProduct = await _productCollection
                .Find(_ => true)                // tüm ürünler
                .SortByDescending(x => x.ProductPrice)
                .Limit(1)
                .FirstOrDefaultAsync();

            // Eğer koleksiyon boşsa 0 döndür
            return maxProduct?.ProductPrice ?? 0;
        }

        public async Task<decimal> GetMinProductPrice()
        {
            var minProduct = await _productCollection
       .Find(_ => true)                // tüm ürünler
       .SortBy(x => x.ProductPrice)
       .Limit(1)
       .FirstOrDefaultAsync();

            return minProduct?.ProductPrice ?? 0;
        }

        public async Task<List<ResultProductDTO>> GetPopularProductsAsync(int count = 10)
        {
            var allProducts = await _productCollection.Find(x => true).ToListAsync();

            var grouped = allProducts
                .GroupBy(x => x.CategoryId)
                .Take(count)
                .Select(g => g.First())
                .ToList();

            return grouped.Select(x => new ResultProductDTO
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                CategoryId = x.CategoryId,
                ProductImageUrl = x.ProductImageUrl,
                ProductDescription = x.ProductDescription
            }).ToList();
        }

        public async Task<GetProductDTO> GetProductByIdAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductDTO>(value);
        }

        public async Task<List<CategoryProductCountDTO>> GetProductCountByCategoryAsync()
        {
            // 1️⃣ Ürünleri CategoryId’ye göre grupla
            var productCounts = await _productCollection.Aggregate()
                .Group(p => p.CategoryId, g => new
                {
                    CategoryId = g.Key,
                    ProductCount = g.Count()
                })
                .ToListAsync();

            // 2️⃣ Category bilgilerini al
            var categories = await _categoryCollection.Find(_ => true).ToListAsync();

            // 3️⃣ Join (manuel)
            var result = productCounts.Select(pc =>
            {
                var category = categories.FirstOrDefault(c => c.CategoryId == pc.CategoryId);

                return new CategoryProductCountDTO
                {
                    CategoryId = pc.CategoryId,
                    CategoryName = category?.CategoryName ?? "Unknown",
                    ProductCount = pc.ProductCount
                };
            }).ToList();

            return result;
        }

        public async Task<PagedResult<ResultProductDTO>> GetProductsByFilterAsync(ResultProductByFilterDTO filter)
        {
            filter.Page = filter.Page <= 0 ? 1 : filter.Page;
            filter.PageSize = filter.PageSize <= 0 ? 10 : filter.PageSize;

            var query = _productCollection.AsQueryable();

            if (!string.IsNullOrEmpty(filter.CategoryId))
                query = query.Where(x => x.CategoryId == filter.CategoryId);

            if (filter.MinPrice != null)
                query = query.Where(x => x.ProductPrice >= filter.MinPrice);

            if (filter.MaxPrice != null)
                query = query.Where(x => x.ProductPrice <= filter.MaxPrice);

            if (!string.IsNullOrEmpty(filter.SearchText))
                query = query.Where(x => x.ProductName.ToLower().Contains(filter.SearchText.ToLower()));

            int totalCount = query.Count();

            var products = query
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            var dtoList = _mapper.Map<List<ResultProductDTO>>(products);

            return new PagedResult<ResultProductDTO>
            {
                Items = dtoList,
                TotalCount = totalCount,
                PageNumber = filter.Page,
                PageSize = filter.PageSize
            };
        }

        public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
        {
            var value = _mapper.Map<Product>(updateProductDTO);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDTO.ProductId, value);
        }
    }
}
