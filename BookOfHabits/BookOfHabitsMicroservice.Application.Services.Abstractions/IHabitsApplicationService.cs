using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Application.Models.Habit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface IHabitsApplicationService
    {
        Task<IEnumerable<HabitModel>> GetAllRoomHabitsAsync(Guid roomId, CancellationToken token = default);
        Task<HabitModel?> GetHabitByIdAsync(Guid id, CancellationToken token = default);
        Task<HabitModel?> AddHabitAsync(CreateHabitModel cardInfo, CancellationToken token = default);
        Task UpdateHabit(UpdateHabitModel cardInfo, CancellationToken token = default);
        Task UpdateDelayHabit(Guid habitId, UpdateDelayModel delayInfo, CancellationToken token = default);
        Task UpdateRepetitionHabit(Guid habitId, UpdateRepetitionModel repetitionInfo, CancellationToken token = default);
        Task UpdateTimeResetIntervalHabit(Guid habitId, UpdateTimeResetIntervalModel timeResetIntervalInfo, CancellationToken token = default);
        Task DeleteHabit(Guid id, CancellationToken token = default);
    }
}
