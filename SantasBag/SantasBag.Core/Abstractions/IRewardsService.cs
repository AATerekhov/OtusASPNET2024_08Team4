using SantasBag.Core.Models;

namespace SantasBug.Core.Abstractions;

public interface IRewardsService
{
    Task<Guid> CreateReward(Reward reward);
    Task<Guid> DeleteReward(Guid id);
    Task<List<Reward>> GetAllRewards();
    Task<Guid> UpdateReward(Guid id, string name, string description, string image, decimal cost, Guid roomId);
}