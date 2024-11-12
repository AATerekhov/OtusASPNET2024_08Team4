using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Enums
{
    [Flags]
    public enum ResetIntervalOptions
    {
        None = 0,
        [Description("Within a day")]
        EveryDay = 1,
        [Description("During the week")]
        Weekday = 2,
        [Description("Within a month")]
        OnceAMonth = 4,
        All = 7
    }
}
