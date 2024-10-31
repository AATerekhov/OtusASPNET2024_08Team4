using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.PropertyRepository
{
    public class DelayRepository : EFRepository<Delay, Guid>, IRepository<Delay, Guid>
    {
        public DelayRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
