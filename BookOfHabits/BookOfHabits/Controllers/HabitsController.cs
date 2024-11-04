using AutoMapper;
using BookOfHabits.Requests.Habit;
using BookOfHabits.Responses.Habit;
using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BookOfHabits.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitsController(IHabitsApplicationService habitsApplicationService,
                                  IInstallCardApplicationService installCardApplicationService,
                                  ICardsApplicationService cardsApplicationService,
                                  IMapper mapper) : ControllerBase
    {
        [HttpGet("room/{roomId:guid}")]
        public async Task<IEnumerable<HabitShortResponse>> GetAllRoomHabits(Guid roomId)
        {
            IEnumerable<HabitModel> habits = await habitsApplicationService.GetAllRoomHabitsAsync(roomId, HttpContext.RequestAborted);
            return habits.Select(mapper.Map<HabitShortResponse>);
        }

        [HttpGet("{id:guid}")]
        public async Task<HabitDetailedResponse> GetHabitById(Guid id)
        {
            var habit = await habitsApplicationService.GetHabitByIdAsync(id, HttpContext.RequestAborted);
            return mapper.Map<HabitDetailedResponse>(habit);
        }

        [HttpPost]
        public async Task<HabitShortResponse> CreateHabit(CreateHabitRequest request)
        {
            var habit = await habitsApplicationService.AddHabitAsync(mapper.Map<CreateHabitModel>(request), HttpContext.RequestAborted);
            return mapper.Map<HabitShortResponse>(habit);
        }

        [HttpPut]
        public async Task UpdateHabitAsync(UpdateHabitRequest request)
        {
            await habitsApplicationService.UpdateHabit(mapper.Map<UpdateHabitModel>(request), HttpContext.RequestAborted);
        }

        [HttpPut("delay/{id:guid}")]
        public async Task UpdateDelayHabitAsync(Guid id, DelayRequest request)
        {
            await habitsApplicationService.UpdateDelayHabit(id, mapper.Map<UpdateDelayModel>(request), HttpContext.RequestAborted);
        }

        [HttpPut("repetition/{id:guid}")]
        public async Task UpdateRepetitionHabitAsync(Guid id, RepetitionRequest request)
        {
            await habitsApplicationService.UpdateRepetitionHabit(id, mapper.Map<UpdateRepetitionModel>(request), HttpContext.RequestAborted);
        }

        [HttpPut("interval/{id:guid}")]
        public async Task UpdateIntervalHabitAsync(Guid id, TimeResetIntervalRequest request)
        {
            await habitsApplicationService.UpdateTimeResetIntervalHabit(id, mapper.Map<UpdateTimeResetIntervalModel>(request), HttpContext.RequestAborted);
        }

        [HttpDelete("{id:guid}")]
        public async Task DeleteHabit(Guid id)
        {
            var habit = await habitsApplicationService.GetHabitByIdAsync(id, HttpContext.RequestAborted);

            await habitsApplicationService.DeleteHabit(id, HttpContext.RequestAborted);
            if (habit?.Card is not null)
                await cardsApplicationService.DeleteCard(habit.Card.Id, HttpContext.RequestAborted);
        }

        [HttpPost("install")]
        public async Task InstallCardInHabitAsync(InstallCardRequest request)
        {
            await installCardApplicationService.InstallCardAsync(mapper.Map<InstallCardModel>(request), HttpContext.RequestAborted);
        }
    }
}
