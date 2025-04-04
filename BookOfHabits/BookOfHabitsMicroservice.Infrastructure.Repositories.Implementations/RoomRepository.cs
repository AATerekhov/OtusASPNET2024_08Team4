using BookOfHabitsMicroservice.Domain.Entity;
using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Repository.Abstractions;
using BookOfHabitsMicroservice.Infrastructure.EntityFramework;
using BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookOfHabitsMicroservice.Infrastructure.Repositories.Implementations
{
    public class RoomRepository : EFRepository<Room, Guid>, IRoomRepository
    {

        readonly ApplicationDbContext _context;
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
