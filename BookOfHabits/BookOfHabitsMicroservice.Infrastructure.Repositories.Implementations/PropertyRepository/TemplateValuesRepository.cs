using BookOfHabitsMicroservice.Domain.Entity.Propertys;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.PropertyRepository
{
    public class TemplateValuesRepository : EFRepository<TemplateValues, Guid>, IRepository<TemplateValues, Guid>
    {
        public TemplateValuesRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
