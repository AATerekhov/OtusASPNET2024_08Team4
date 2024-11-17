using BroadcasterMicroservice.Domain.Repository.Abstractions;
using BroadcasterMicroservice.Infrastructure.MongoDbContext.Abstraction;
using BroadcasterService.Domain.Entity.Base;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BroadcasterMicroservice.Infrastructure.Implementations.Base
{
    public class BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
                                               where TEntity : Entity<TId> where TId : struct
    {
        protected readonly IMongoDBContext _mongoContext;
        protected IMongoCollection<TEntity> _dbCollection;

        protected BaseRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCollection = _mongoContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public virtual async Task AddAsync(TEntity entity, CancellationToken token = default)
        {
            if (entity is null)
                throw new ArgumentNullException(typeof(TEntity).Name + " object is null");
            await _dbCollection.InsertOneAsync(entity, cancellationToken: token);
        }

        public virtual async Task DeleteAsync(TId id, CancellationToken token = default)
        {
            var objectId = new ObjectId(id.ToBson());
            await _dbCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", objectId), cancellationToken: token);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default)
        {
            var all = await _dbCollection.FindAsync(Builders<TEntity>.Filter.Empty, cancellationToken: token);
            return await all.ToListAsync(cancellationToken: token);
        }

        public virtual async Task<TEntity?> GetByIdAsync(TId id, CancellationToken token = default)
        {
            var objectId = new ObjectId(id.ToBson());

            FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", objectId);

            return await _dbCollection.FindAsync(filter, cancellationToken: token).Result.FirstOrDefaultAsync(token);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken token = default) =>
            await _dbCollection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id.ToBson()), entity, cancellationToken: token);
    }
}
