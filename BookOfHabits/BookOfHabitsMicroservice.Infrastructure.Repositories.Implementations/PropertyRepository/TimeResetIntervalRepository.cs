using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.PropertyRepository
{
    public class TimeResetIntervalRepository : EFRepository<TimeResetInterval, Guid>, IRepository<TimeResetInterval, Guid>
    {
        public TimeResetIntervalRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
