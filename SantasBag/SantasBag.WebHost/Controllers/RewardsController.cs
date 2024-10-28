using Microsoft.AspNetCore.Mvc;
using SantasBag.Contracts;
using SantasBag.Core.Models;
using SantasBag.WebHost.Contracts;
using SantasBug.Core.Abstractions;

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
    public async Task<ActionResult<List<RewardResponse>>> GetRewards()
    {
        var rewards = await _rewardsService.GetAllRewards();
        var response = rewards.Select(r => new RewardResponse(r.Id, r.Name, r.Description, r.Image, r.Cost, r.RoomId));
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<List<RewardResponse>>> CreateReward([FromBody] RewardTemplate request)
    {
        var (newReward, error) = Reward.Create(
            request.Name,
            request.Description,
            request.Image,
            request.Cost,
            request.RoomId);

        if (!string.IsNullOrEmpty(error))
            return BadRequest(error);
        var rewardId = await _rewardsService.CreateReward(newReward);
        return Ok(rewardId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdatReward(Guid id, [FromBody] RewardTemplate request)
    {
        var rewardId = await _rewardsService.UpdateReward(id, request.Name, request.Description, request.Image, request.Cost, request.RoomId);
        return Ok(rewardId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteReward(Guid id)
    {
        return Ok(await _rewardsService.DeleteReward(id));
    }

}
