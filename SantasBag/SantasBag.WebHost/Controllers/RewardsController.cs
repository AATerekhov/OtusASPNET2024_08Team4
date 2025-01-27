using Microsoft.AspNetCore.Mvc;
using SantasBag.Contracts;
using SantasBag.Core.Models;
using SantasBag.WebHost.Contracts;
using SantasBag.Core.Abstractions;
using Microsoft.AspNetCore.Cors;
using System.Linq;

namespace SantasBag.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RewardsController : ControllerBase
{
    private readonly IRewardsService _rewardsService;
    public RewardsController(IRewardsService rewardsService)
    {
        _rewardsService = rewardsService;
    }


    /// <summary>
    /// Поучение списка всех наград
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetRewards")]
    [EnableCors("AllowAllFront")]
    public async Task<ActionResult<List<RewardResponse>>> GetRewardsAsync()
    {
        var rewards = await _rewardsService.GetAllRewards(HttpContext.RequestAborted);
        var response = rewards.Select(r => new RewardResponse(r.Id, r.Name, r.Description, r.Image, r.Cost, r.InstantBuy, r.RoomId));
        return Ok(response);
    }

    /// <summary>
    /// Поучение списка всех наград
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetRewardsByRoom/{roomId:guid}")]
    [EnableCors("AllowAllFront")]
    public async Task<ActionResult<List<RewardResponse>>> GetRewardsByRoomIdAsync(Guid roomId)
    {
        var rewards = await _rewardsService.GetRewardByRoomId(roomId, HttpContext.RequestAborted);
        var response = rewards.Select(r => new RewardResponse(r.Id, r.Name, r.Description, r.Image, r.Cost, r.InstantBuy, r.RoomId));
        return Ok(response);
    }

    /// <summary>
    /// Получение конкретной награды, по Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetRewards/{id:guid}")]
    [EnableCors("AllowAllFront")]
    public async Task<ActionResult<RewardResponse>> GetRewardByIdAsync(Guid id)
    {
        var reward = await _rewardsService.GetRewardById(id, HttpContext.RequestAborted);
        if (reward == null)
            return NotFound(id);
        return Ok(reward);
    }

    /// <summary>
    /// Создание новой награды
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("CreateReward")]
    [EnableCors("AllowAllFront")]
    public async Task<ActionResult<List<RewardResponse>>> CreateRewardAsync([FromBody] RewardTemplate request)
    {
        var newReward= Reward.Create(
            request.Name,
            request.Description,
            request.Image,
            request.Cost,
            request.InstantBuy,
            request.RoomId);

        var rewardId = await _rewardsService.CreateReward(newReward, HttpContext.RequestAborted);
        return Ok(rewardId);
    }

    /// <summary>
    /// Обновление конкретной награды
    /// </summary>
    /// <param name="id"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut("UpdateReward/{id:guid}")]
    [EnableCors("AllowAllFront")]
    public async Task<ActionResult<Guid>> UpdatRewardAsync(Guid id, [FromBody] RewardTemplate request)
    {
        var rewardId = await _rewardsService.UpdateReward(id, request.Name, request.Description, request.Image, request.Cost, request.InstantBuy, request.RoomId, HttpContext.RequestAborted);
        return Ok(rewardId);
    }


    /// <summary>
    /// Удаление конкретной награды
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("DeleteReward/{id:guid}")]
    [EnableCors("AllowAllFront")]
    public async Task<ActionResult<Guid>> DeleteRewardAsync(Guid id)
    {
        return Ok(await _rewardsService.DeleteReward(id, HttpContext.RequestAborted));
    }



}
