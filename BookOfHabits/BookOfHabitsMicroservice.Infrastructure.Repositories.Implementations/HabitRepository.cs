using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations
{
    public class HabitRepository : EFRepository<Habit, Guid>, IHabitsRepository
    {
        readonly ApplicationDbContext _context;
        public HabitRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Habit>> GetDetailedHabitsByRoomId(Guid roomId, CancellationToken token)
        {
            var query = _context.Set<Habit>()
                                .Where(x => x.RoomId.Equals(roomId) && !x.IsUsed)
                                .Include(x => x.Owner)
                                .Include(x => x.Delay)
                                .Include(x => x.TimeResetInterval)
                                .Include(x => x.Repetition)
                                .Include(x => x.Room)
                                .Include(x => x.Card).ThenInclude(c => c.TemplateValues)
                                .AsNoTracking();

            return await query.ToListAsync(token);
        }
    }
}
