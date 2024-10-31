using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class UpdateTimeResetIntervalModel:ICreateModel
    {
        public ResetIntervalOptions Options { get; init; }
        public int TimeTheDay { get; init; }
        public WeekDays WeekDays { get; init; }
        public int NumberDayOfTheMonth { get; init; }
    }
}
