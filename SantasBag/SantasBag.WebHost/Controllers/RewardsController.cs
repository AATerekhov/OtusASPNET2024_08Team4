using Microsoft.AspNetCore.Mvc;
using SantasBag.Contracts;
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

}
