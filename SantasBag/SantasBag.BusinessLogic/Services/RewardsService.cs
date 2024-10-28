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

    public async Task<List<Reward>> GetAllRewards()
    {
        return await _rewardsRepository.Get();
    }

    public async Task<Guid> CreateReward(Reward reward)
    {
        return await _rewardsRepository.Create(reward);
    }
    public async Task<Guid> UpdateReward(Guid id, string name, string description, string image, decimal cost, Guid roomId)
    {
        return await _rewardsRepository.Update(id, name, description, image, cost, roomId);
    }
    public async Task<Guid> DeleteReward(Guid id)
    {
        return await _rewardsRepository.Delete(id);
    }
}
