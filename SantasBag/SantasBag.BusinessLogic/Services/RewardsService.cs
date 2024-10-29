using SantasBag.Core.Models;
using SantasBug.Core.Abstractions;

namespace SantasBag.BusinessLogic.Services;

public class RewardsService : IRewardsService
{
    private readonly IRewardsRepository _rewardsRepository;

    public RewardsService(IRewardsRepository rewardsRepository)
    {
        _rewardsRepository = rewardsRepository;
    }

    public async Task<List<Reward>> GetAllRewards(CancellationToken cancellationToken)
    {
        return await _rewardsRepository.Get(cancellationToken);
    }

    public async Task<Guid> CreateReward(Reward reward, CancellationToken cancellationToken)
    {
        return await _rewardsRepository.Create(reward, cancellationToken);
    }
    public async Task<Guid> UpdateReward(Guid id, string name, string description, string image, decimal cost, Guid roomId, CancellationToken cancellationToken)
    {
        return await _rewardsRepository.Update(id, name, description, image, cost, roomId, cancellationToken);
    }
    public async Task<Guid> DeleteReward(Guid id, CancellationToken cancellationToken)
    {
        return await _rewardsRepository.Delete(id, cancellationToken);
    }
}
