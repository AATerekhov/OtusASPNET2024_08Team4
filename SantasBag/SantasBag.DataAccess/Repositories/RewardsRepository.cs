﻿using Microsoft.EntityFrameworkCore;
using SantasBag.Core.Models;
using SantasBug.Core.Abstractions;
using SantasBug.DataAccess.Entities;

namespace SantasBug.DataAccess.Repositories;

public class RewardsRepository : IRewardsRepository
{
    private readonly SantasBagDbContext _context;

    public RewardsRepository(SantasBagDbContext context)
    {
        _context = context;
    }

    public async Task<List<Reward>> Get()
    {
        var rewardEntities = await _context.Rewards
            .AsNoTracking()
            .ToListAsync();
        var rewards = rewardEntities
            .Select(b=>Reward.Create(b.Name, b.Description, b.Image, b.Cost, b.RoomId).Reward)
            .ToList();
        return rewards;
    }

    public async Task<Guid> Create(Reward reward)
    {
        var rewardEntity = new RewardEntity
        {
            Name = reward.Name,
            Description = reward.Description,
            Image = reward.Image,
            Cost = reward.Cost,
            RoomId = reward.RoomId
        };
        await _context.Rewards.AddAsync(rewardEntity);
        await _context.SaveChangesAsync();
        return rewardEntity.Id;
    }

    public async Task<Guid> Update(Guid id, string name, string description, string image, decimal cost, Guid roomId)
    {
        await _context.Rewards
            .Where(b=>b.Id==id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Name, b => name)
                .SetProperty(b => b.Description, b => description)
                .SetProperty(b => b.Image, b => image)
                .SetProperty(b => b.Cost, b => cost)
                .SetProperty(b => b.RoomId, b => roomId));
        return id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Rewards
            .Where(b => b.Id == id)
            .ExecuteDeleteAsync();
        return id;
    }
}