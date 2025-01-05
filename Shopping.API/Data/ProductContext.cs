using MongoDB.Driver;
using Shopping.Api.Models;

namespace Shopping.Api.Data
{
    public class ProductContext
    {
        private IMongoDatabase database { get; }
        public IMongoCollection<Product> Products { get; }

        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            
            ProductContextSeed.SeedData(Products);
        }
    }
}