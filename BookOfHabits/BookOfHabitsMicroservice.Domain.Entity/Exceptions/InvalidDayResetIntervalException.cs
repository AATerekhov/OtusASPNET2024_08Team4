using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Exceptions
{
    internal class InvalidDayResetIntervalException(int day) : ArgumentException("The range should be within a month", nameof(day))
    {
        public int Day => day;
    }
}
