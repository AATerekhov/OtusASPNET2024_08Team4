using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations
{
    public class CoinsRepository : EFRepository<Coins, Guid>, ICoinsRepository
    {
        readonly ApplicationDbContext _context;
        public CoinsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Coins?> GetDetailedCoinsByIdAsync(Guid id, CancellationToken token = default) 
        {
            var query = _context.Set<Coins>()
                                .Where(x => x.Id.Equals(id))
                                .Include(x => x.Habit).ThenInclude(x => x.Card).ThenInclude(x => x.TemplateValues)
                                .Include(x => x.Habit).ThenInclude(x => x.Room)
                                .Include(x => x.Habit).ThenInclude(x => x.Owner)
                                .Include(x => x.Room).ThenInclude(x => x.Manager);
            
            return await query.SingleOrDefaultAsync(token);
        }
        public async Task<Coins?> GetCoinsByIdAsync(Guid id, CancellationToken token = default) =>
            await base.GetByIdAsync(
                x => x.Id.Equals(id),
                includes: $"{nameof(Coins.Habit)},{nameof(Coins.Room)}",
                asNoTracking: true,
                token: token);
    }
}
