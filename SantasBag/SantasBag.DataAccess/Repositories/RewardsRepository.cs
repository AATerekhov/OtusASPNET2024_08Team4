using Microsoft.EntityFrameworkCore;
using SantasBag.Core.Abstractions;
using SantasBag.Core.Models;
using SantasBag.DataAccess.Entities;

namespace SantasBag.DataAccess.Repositories;

public class RewardsRepository : IRewardsRepository<RewardEntity>
{
    private readonly SantasBagDbContext _context;

    public RewardsRepository(SantasBagDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reward>> Get(CancellationToken cancellationToken)
    {
        var rewardEntities = await _context.Rewards
            .AsNoTracking()
            .ToListAsync();
        var rewards = rewardEntities
            .Select(b=>Reward.Map(b.Id, b.Name, b.Description, b.Image, b.Cost, b.InstantBuy, b.RoomId))
            .ToList();
        return rewards;
    }

    public async Task<Guid> Create(RewardEntity reward, CancellationToken cancellationToken)
    {
        var rewardEntity = reward; /*  new RewardEntity
        {
            Name = reward.Name,
            Description = reward.Description,
            Image = reward.Image,
            Cost = reward.Cost,
            RoomId = reward.RoomId
        };*/
        await _context.Rewards.AddAsync(rewardEntity);
        await _context.SaveChangesAsync();
        return rewardEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string name, string description, string image, decimal cost, bool instantBuy, Guid roomId, CancellationToken cancellationToken)
    {
        await _context.Rewards
            .Where(b=>b.Id==id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Image, b => image)
                .SetProperty(b => b.Cost, b => cost)
                .SetProperty(b => b.InstantBuy, b => instantBuy)
                .SetProperty(b => b.RoomId, b => roomId));
        return id;
    }

    public async Task<Guid> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _context.Rewards
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }

    public async Task<Reward> GetById(Guid id, CancellationToken cancellationToken)
    {
        var rewardEntities = await _context.Rewards
            .AsNoTracking()
            .ToListAsync();
        var reward = rewardEntities
            .Select(b => Reward.Map(b.Id, b.Name, b.Description, b.Image, b.Cost, b.InstantBuy, b.RoomId))
            .First(r=>r.Id==id); //добавить проверку на null
        return reward;
    }
}
