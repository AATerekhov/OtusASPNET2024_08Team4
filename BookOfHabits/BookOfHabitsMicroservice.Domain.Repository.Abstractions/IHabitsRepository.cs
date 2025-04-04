using BookOfHabitsMicroservice.Domain.Entity;

namespace BookOfHabitsMicroservice.Domain.Repository.Abstractions
{
    public interface IHabitsRepository : IRepository<Habit, Guid>
    {
        public Task<IEnumerable<Habit>> GetDetailedHabitsByRoomId(Guid roomId, CancellationToken token);
    }
}
