using BroadcasterService.Domain.Entity.Base;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BroadcasterMicroservice.Domain.Entity.MongoModel
{
    public abstract class MongoEntity<TEntity, TId>(TEntity entity)
        where TEntity : Entity<TId>
        where TId : struct
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ObjectId { get; set; }
        public TEntity? Object { get; protected set; } = entity;

    }
}
