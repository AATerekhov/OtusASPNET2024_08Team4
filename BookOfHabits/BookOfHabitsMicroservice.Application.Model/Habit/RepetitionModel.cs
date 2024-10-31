using BookOfHabitsMicroservice.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class RepetitionModel: IModel<Guid>
    {
        public Guid Id { get; init; }
        public int MaxCountPositive { get; init; }
        public int MaxCountNegative { get; init; }
        public bool IsLimit { get; init; }
        public int CountLimit { get; init; }
    }
}
