using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations
{
    public class RoomRepository : EFRepository<Room, Guid>, IRepository<Room, Guid>
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
