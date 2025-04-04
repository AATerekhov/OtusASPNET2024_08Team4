using AutoMapper;
using BookOfHabits.Requests.Cains;
using BookOfHabits.Responses.Coins;
using BookOfHabitsMicroservice.Application.Models.Coins;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookOfHabits.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class CoinsController(ICoinsApplicationService coinsApplicationService,
                                 IChooseHabitApplicationService chooseHabitApplicationService,
                                 IMapper mapper) : ControllerBase
    {
        [HttpGet("room/{roomId:guid}")]
        public async Task<IEnumerable<CoinsShortResponse>> GetAllRoomCoins(Guid roomId)
        {
            IEnumerable<CoinsModel> bags = await coinsApplicationService.GetAllRoomCoinsAsync(roomId, HttpContext.RequestAborted);
            return bags.Select(mapper.Map<CoinsShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<CoinsDetailedResponse> GetCoinsById(Guid id)
        {
            var coins = await coinsApplicationService.GetCoinsByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<CoinsDetailedResponse>(coins);
        }

        [HttpPut]
        public async Task<bool> UpdateCoinsAsync(UpdateCoinsRequest request)
        {
            return await coinsApplicationService.UpdateCoins(mapper.Map<UpdateCoinsModel>(request), HttpContext.RequestAborted);
        }

        [HttpDelete("{id:guid}")]
        public async Task<bool> DeleteCoins(Guid id)
        {
            return await coinsApplicationService.DeleteCoins(id, HttpContext.RequestAborted);
        }

        [HttpPost]
        public async Task<CoinsShortResponse> ChooseHabitInTheRoomAsync(ChooseHabitRequest request)
        {
            var coins = await chooseHabitApplicationService.ChooseHabitInTheRoomAsync(mapper.Map<ChooseHabitModel>(request), HttpContext.RequestAborted);
            return mapper.Map<CoinsShortResponse>(coins);
        }
    }
}
