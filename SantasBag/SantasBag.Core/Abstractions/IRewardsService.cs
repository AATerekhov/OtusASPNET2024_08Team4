using SantasBag.Core.Models;

namespace SantasBag.Core.Abstractions;

public interface IRewardsService
{
    Task<Guid> CreateReward(Reward reward, CancellationToken cancellationToken);
    Task<Guid> DeleteReward(Guid id, CancellationToken cancellationToken);
    Task<List<Reward>> GetAllRewards(CancellationToken cancellationToken);
    Task<Reward> GetRewardById(Guid id, CancellationToken cancellationToken);
    Task<Guid> UpdateReward(Guid id, string name, string description, string image, decimal cost, Guid roomId, CancellationToken cancellationToken);
}