using SantasBag.Core.Models;
using SantasBag.Core.Abstractions;
using SantasBag.DataAccess.Entities;

namespace SantasBag.BusinessLogic.Services;

public class RewardsService : IRewardsService
{
    private readonly IRewardsRepository<RewardEntity> _rewardsRepository;

    public RewardsService(IRewardsRepository<RewardEntity> rewardsRepository)
    {
        _rewardsRepository = rewardsRepository;
    }

    public async Task<List<Reward>> GetAllRewards(CancellationToken cancellationToken)
    {
        return await _rewardsRepository.Get(cancellationToken);
    }

    public async Task<Guid> CreateReward(Reward reward, CancellationToken cancellationToken)
    {
        var rewardEntity = new RewardEntity
        {
            Name = reward.Name,
            Description = reward.Description,
            Image = reward.Image,
            Cost = reward.Cost,
            RoomId = reward.RoomId
        };
        return await _rewardsRepository.Create(rewardEntity, cancellationToken);
    }
    public async Task<Guid> UpdateReward(Guid id, string name, string description, string image, decimal cost, bool instantBuy, Guid roomId, CancellationToken cancellationToken)
    {
        return await _rewardsRepository.Update(id, name, description, image, cost, instantBuy, roomId, cancellationToken);
    }
    public async Task<Guid> DeleteReward(Guid id, CancellationToken cancellationToken)
    {
        return await _rewardsRepository.Delete(id, cancellationToken);
    }

    public async Task<Reward> GetRewardById(Guid id, CancellationToken cancellationToken)
    {
        return await _rewardsRepository.GetById(id, cancellationToken);
    }

    public async Task<List<Reward>> GetRewardByRoomId(Guid roomId, CancellationToken cancellationToken)
    {
        var rewardsByRoom = (await _rewardsRepository.Get(cancellationToken))
            .Where(r => r.RoomId == roomId).ToList();
        return rewardsByRoom;
    }
}
