using BookOfHabitsMicroservice.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Repository.Abstractions
{
    public interface IRoomRepository : IRepository<Room, Guid>
    {
    }
}
