using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Enums
{
    [Flags]
    public enum ResetIntervalOptions
    {
        None = 0,
        EveryDay = 1,
        Weekday = 2,
        OnceAMonth = 4,
        All = 7
    }
}
