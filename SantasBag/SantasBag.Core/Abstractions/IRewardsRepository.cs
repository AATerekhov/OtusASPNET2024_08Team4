using SantasBag.Core.Models;

namespace SantasBag.Core.Abstractions;

public interface IRewardsRepository<T>
{
    Task<Guid> Create(T reward, CancellationToken cancellationToken);
    Task<Guid> Delete(Guid id, CancellationToken cancellationToken);
    Task<List<Reward>> Get(CancellationToken cancellationToken);
    Task<Guid> Update(Guid id, string name, string description, string image, decimal cost, bool instantBuy, Guid roomId, CancellationToken cancellationToken);
    Task<Reward> GetById(Guid id, CancellationToken cancellationToken);
}