using BookOfHabitsMicroservice.Application.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class UpdateDelayModel : ICreateModel
    {
        public bool IsAfterATime { get; init; }
        public int AfterTime { get; init; }
        public bool IsEndless { get; init; }
        public int DurationTime { get; init; }
    }
}
