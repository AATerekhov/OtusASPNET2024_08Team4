
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Abstraction;
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BroadcasterMicroservice.Infrastructure.MongoDbContext
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase _db;
        private readonly MongoClient _mongoClient;
        public IClientSessionHandle? Session { get; set; }
        public MongoDBContext(IOptions<MongoSettings> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.Connection);
            _db = _mongoClient.GetDatabase(configuration.Value.DatabaseName);
            
        }
        public IMongoCollection<TDocument> GetCollection<TDocument>(string name)
        {
            return _db.GetCollection<TDocument>(name);
        }
    }
}
