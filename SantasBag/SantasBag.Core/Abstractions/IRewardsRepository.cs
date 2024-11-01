using SantasBag.Core.Models;

namespace SantasBug.Core.Abstractions;

public interface IRewardsRepository
{
    Task<Guid> Create(Reward reward, CancellationToken cancellationToken);
    Task<Guid> Delete(Guid id, CancellationToken cancellationToken);
    Task<List<Reward>> Get(CancellationToken cancellationToken);
    Task<Guid> Update(Guid id, string name, string description, string image, decimal cost, Guid roomId, CancellationToken cancellationToken);
    Task<Reward> GetById(Guid id, CancellationToken cancellationToken);
}