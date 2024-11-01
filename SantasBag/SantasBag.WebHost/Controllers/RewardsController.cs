using Microsoft.AspNetCore.Mvc;
using SantasBag.Contracts;
using SantasBag.Core.Models;
using SantasBag.WebHost.Contracts;
using SantasBag.Core.Abstractions;

namespace SantasBag.Controllers;

[ApiController]
[Route("controller")]
public class RewardsController : ControllerBase
{
    private readonly IRewardsService _rewardsService;
    public RewardsController(IRewardsService rewardsService)
    {
        _rewardsService = rewardsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<RewardResponse>>> GetRewardsAsync(CancellationToken cancellationToken)
    {
        var rewards = await _rewardsService.GetAllRewards(cancellationToken);
        var response = rewards.Select(r => new RewardResponse(r.Id, r.Name, r.Description, r.Image, r.Cost, r.RoomId));
        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RewardResponse>> GetRewardByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var reward = await _rewardsService.GetRewardById(id, cancellationToken );
        if (reward == null)
            return NotFound(id);
        return Ok(reward);
    }

    [HttpPost]
    public async Task<ActionResult<List<RewardResponse>>> CreateRewardASync([FromBody] RewardTemplate request, CancellationToken cancellationToken)
    {
        var newReward= Reward.Create(
            request.Name,
            request.Description,
            request.Image,
            request.Cost,
            request.RoomId);

        var rewardId = await _rewardsService.CreateReward(newReward, cancellationToken);
        return Ok(rewardId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdatRewardAsync(Guid id, [FromBody] RewardTemplate request, CancellationToken cancellationToken)
    {
        var rewardId = await _rewardsService.UpdateReward(id, request.Name, request.Description, request.Image, request.Cost, request.RoomId, cancellationToken);
        return Ok(rewardId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteRewardAsync(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _rewardsService.DeleteReward(id, cancellationToken));
    }

}
