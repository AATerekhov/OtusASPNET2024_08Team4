using BookOfHabitsMicroservice.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Room : Entity<Guid>
    {
        public Room(Guid id) : base(id)
        {
        }
    }
}
