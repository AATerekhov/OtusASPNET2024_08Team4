using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Enums
{
    [Flags]
    public enum OptionCoins
    {
        None = 0,
        FallingLevel = 1,
        AutoPayment = 2,
        CheckingLimit = 4,
        CheckingReport = 8
    }
}
