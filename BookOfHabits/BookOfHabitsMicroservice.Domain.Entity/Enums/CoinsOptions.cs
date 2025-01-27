using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Enums
{
    [Flags]
    public enum CoinsOptions
    {
        None = 0,
        [Description("Behavior with a decreasing result premium")]
        FallingLevel = 1,
        [Description("Automatic coin accrual")]
        AutoPayment = 2,
        [Description("Automatic checking of execution limits")]
        CheckingLimit = 4,
        [Description("Sensitive to the availability of the report - not empty")]
        CheckingReport = 8,
        All = 15
    }
}
