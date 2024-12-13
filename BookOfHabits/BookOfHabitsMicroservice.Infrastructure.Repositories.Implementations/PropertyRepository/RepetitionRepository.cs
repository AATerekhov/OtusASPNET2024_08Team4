using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.PropertyRepository
{
    public class RepetitionRepository : EFRepository<Repetition, Guid>, IRepository<Repetition, Guid>
    {
        public RepetitionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
