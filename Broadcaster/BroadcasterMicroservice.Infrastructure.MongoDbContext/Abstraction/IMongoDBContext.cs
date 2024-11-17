using MongoDB.Driver;

namespace BroadcasterMicroservice.Infrastructure.MongoDbContext.Abstraction
{
    public interface IMongoDBContext
    {
        IMongoCollection<TDocument> GetCollection<TDocument>(string name);
    }
}
