using BookOfHabitsMicroservice.Application.Models.Habit;
using BookOfHabitsMicroservice.Domain.Entity;
using System.Net.Http;

namespace BookOfHabitsMicroservice.Application.Services.Abstractions
{
    public interface IHabitsApplicationService
    {
        Task<IEnumerable<HabitModel>> GetAllRoomHabitsAsync(Guid roomId, CancellationToken token = default);
        Task<IEnumerable<HabitModel>>  GetRoomHabitsByPersonAsync(Guid roomId, Guid personId, Guid userId, CancellationToken token = default);
        Task<HabitModel?> GetHabitByIdAsync(Guid id, CancellationToken token = default);
        Task<HabitModel?> AddHabitAsync(CreateHabitModel cardInfo, CancellationToken token = default);
        Task<bool> UpdateHabit(UpdateHabitModel cardInfo, CancellationToken token = default);
        Task UpdateDelayHabit(Guid habitId, UpdateDelayModel delayInfo, CancellationToken token = default);
        Task UpdateRepetitionHabit(Guid habitId, UpdateRepetitionModel repetitionInfo, CancellationToken token = default);
        Task UpdateTimeResetIntervalHabit(Guid habitId, UpdateTimeResetIntervalModel timeResetIntervalInfo, CancellationToken token = default);
        Task<bool> DeleteHabit(Guid id, CancellationToken token = default);
    }
}
