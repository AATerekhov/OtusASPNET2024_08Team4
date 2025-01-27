using BroadcasterService.Domain.Entity.Base;

namespace BroadcasterMicroservice.Domain.Repository.Abstractions
{
    public interface IRepository<TEntity, in TId> where TEntity : Entity<TId> where TId : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken token = default);
        Task<TEntity?> GetByIdAsync(TId id, CancellationToken token = default);
        Task AddAsync(TEntity entity, CancellationToken token = default);
        Task UpdateAsync(TEntity entity, CancellationToken token = default);
        Task DeleteAsync(TId id, CancellationToken token = default);        
    }
}
