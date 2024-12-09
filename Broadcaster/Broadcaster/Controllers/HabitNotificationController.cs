using AutoMapper;
using Broadcaster.Application.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Broadcaster.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HabitNotificationController(IHabitNotificationService habitNotificationService)
    {
        //[HttpGet]
        //public async Task<IEnumerable<HabitShortResponse>> GetAllRoomHabits(Guid roomId)
        //{
        //    IEnumerable<HabitModel> habits = await habitsApplicationService.GetAllRoomHabitsAsync(roomId, HttpContext.RequestAborted);
        //    return habits.Select(mapper.Map<HabitShortResponse>);
        //}

        //[HttpGet("{id:guid}")]
        //public async Task<HabitDetailedResponse> GetHabitById(Guid id)
        //{
        //    var habit = await habitsApplicationService.GetHabitByIdAsync(id, HttpContext.RequestAborted);
        //    return mapper.Map<HabitDetailedResponse>(habit);
        //}

        //[HttpPost]
        //public async Task<HabitShortResponse> CreateHabit(CreateHabitRequest request)
        //{
        //    var habit = await habitsApplicationService.AddHabitAsync(mapper.Map<CreateHabitModel>(request), HttpContext.RequestAborted);
        //    return mapper.Map<HabitShortResponse>(habit);
        //}

    }
}
