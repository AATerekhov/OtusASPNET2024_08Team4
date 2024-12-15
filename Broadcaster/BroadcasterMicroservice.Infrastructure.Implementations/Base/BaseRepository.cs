using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterMicroservice.Domain.Repository.Abstractions;
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Abstraction;
using BroadcasterService.Domain.Entity.Base;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BroadcasterMicroservice.Infrastructure.Implementations.Base
{
    public class BaseRepository<TMongo,TEntity, TId> : IMongoRepository<TMongo,TEntity, TId>
        where TMongo : MongoEntity<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<TMongo> _dbCollection;

        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TMongo>(typeof(TMongo).Name);
        }
        public virtual async Task AddAsync(TMongo entity, CancellationToken token = default)
        {
            if (entity is null)
                throw new ArgumentNullException(typeof(TMongo).Name + " object is null");
            await _dbCollection.InsertOneAsync(entity, cancellationToken: token);
        }

        public virtual async Task DeleteAsync(string id, CancellationToken token = default)
        {
            var objectId = new ObjectId(id.ToBson());
            await _dbCollection.DeleteOneAsync(Builders<TMongo>.Filter.Eq("_objectid", objectId), cancellationToken: token);
        }

        public virtual async Task<IEnumerable<TMongo>> GetAllAsync(CancellationToken token = default)
        {
            var all = await _dbCollection.FindAsync(Builders<TMongo>.Filter.Empty, cancellationToken: token);
            return await all.ToListAsync(cancellationToken: token);
        }

        public virtual async Task<TMongo?> GetByIdAsync(string id, CancellationToken token = default)
        {
            var objectId = new ObjectId(id.ToBson());

            FilterDefinition<TMongo> filter = Builders<TMongo>.Filter.Eq("_objectid", objectId);

            return await _dbCollection.FindAsync(filter, cancellationToken: token).Result.FirstOrDefaultAsync(token);
        }

        public virtual async Task UpdateAsync(TMongo entity, CancellationToken token = default) =>
            await _dbCollection.ReplaceOneAsync(Builders<TMongo>.Filter.Eq("_objectid", entity.ObjectId.ToBson()), entity, cancellationToken: token);
    }
}
