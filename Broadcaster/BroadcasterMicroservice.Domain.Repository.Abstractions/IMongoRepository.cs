using BroadcasterMicroservice.Domain.Entity.MongoModel;
using BroadcasterService.Domain.Entity.Base;

namespace BroadcasterMicroservice.Domain.Repository.Abstractions
{
    public interface IMongoRepository<TMongo,TEntity,out TId> 
        where TMongo : MongoEntity<TEntity, TId>
        where TEntity : Entity<TId>
        where TId : struct
    {
        Task<IEnumerable<TMongo>> GetAllAsync(CancellationToken token = default);
        Task<TMongo?> GetByIdAsync(string objectId, CancellationToken token = default);
        Task AddAsync(TMongo entity, CancellationToken token = default);
        Task UpdateAsync(TMongo entity, CancellationToken token = default);
        Task DeleteAsync(string objectId, CancellationToken token = default);
    }
}
