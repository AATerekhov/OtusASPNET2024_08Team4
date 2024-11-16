using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Domain.Entity.Exceptions
{

    internal class InvalidTimeResetIntervalException(int time) : ArgumentException("The range should be within a day", nameof(time))
    {
        public int Time => time;
    }
}
