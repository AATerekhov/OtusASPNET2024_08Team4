using BookOfHabitsMicroservice.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class Repetition(Guid id): Property(id, "Repetition")
    {
    }
}
