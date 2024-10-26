using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Enums
{
    [Flags]
    public enum HabitOptions
    {
        None = 0,
        Delayed =1,
        Reset = 2,
        Repetition = 4,
    }
}
