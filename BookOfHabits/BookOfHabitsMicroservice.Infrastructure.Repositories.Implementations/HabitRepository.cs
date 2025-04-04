using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations
{
    public class HabitRepository : EFRepository<Habit, Guid>, IRepository<Habit, Guid>
    {
        public HabitRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
