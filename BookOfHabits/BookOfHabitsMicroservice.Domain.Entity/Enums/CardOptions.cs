using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Enums
{
    [Flags]
    public enum CardOptions
    {
        None = 0,
        Status = 1,
        Value = 2,
        Check = 4,
        Report = 8,
        Tags = 16,
        Positive = 32,
        Negative = 64,
        Result = 128,
        All = 255
    }
}
