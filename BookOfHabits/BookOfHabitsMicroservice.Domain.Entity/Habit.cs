using BookOfHabitsMicroservice.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity
{
    public class Habit : Entity<Guid>
    {
        public Habit(Guid id) : base(id)
        {
        }
    }
}
