
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var pipeline = new[]
            {
                new BsonDocument("$sort", new BsonDocument("ProductPrice", -1)),
                new BsonDocument("$limit", 1),
                new BsonDocument("$project", new BsonDocument
                {
                    { "_id", 0 },
                    { "ProductName", 1 }
                })
            };

            var cursor = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var doc = await cursor.FirstOrDefaultAsync();

            return doc?["ProductName"]?.AsString ?? string.Empty;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var pipeline = new[]
            {
                new BsonDocument("$sort", new BsonDocument("ProductPrice", 1)),
                new BsonDocument("$limit", 1),
                new BsonDocument("$project", new BsonDocument
                {
                    { "_id", 0 },
                    { "ProductName", 1 }
                })
            };

            var cursor = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var doc = await cursor.FirstOrDefaultAsync();

            return doc?["ProductName"]?.AsString ?? string.Empty;
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var pipeline = new[]
            {
               new BsonDocument("$group", new BsonDocument
               {
                   { "_id", BsonNull.Value },
                   { "averagePrice", new BsonDocument("$avg", "$ProductPrice") }
               })
            };

            var cursor = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var doc = await cursor.FirstOrDefaultAsync();

            if (doc == null || !doc.Contains("averagePrice"))
                return 0;

            return doc["averagePrice"].ToDecimal();
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
