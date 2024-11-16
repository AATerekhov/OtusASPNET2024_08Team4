using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Enums
{
    [Flags]
    public enum HabitOptions
    {
        None = 0,
        [Description("Achieving the result after a considerable time")]
        Delayed =1,
        [Description("Important daily tasks, job, working, run, training")]
        Reset = 2,
        [Description("Habits, regimen, custom")]
        Repetition = 4,
        All = 7,
    }
}
