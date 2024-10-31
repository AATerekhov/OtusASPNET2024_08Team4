using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using System.Runtime.CompilerServices;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class TimeResetInterval : Property
    {
        public Habit? Habit { get; }
        public ResetIntervalOptions Options { get; private set; }
        public TimeOnly TimeTheDay  { get; private set; }
        public WeekDays WeekDays { get; private set; }
        public int NumberDayOfTheMonth { get; private set; }

        public TimeResetInterval(Guid id,Habit habit, ResetIntervalOptions options, TimeOnly timeTheDay, WeekDays weekDays, int numberDayOfTheMonth)
            :base(id, "TimeResetInterval")
        {
            Habit = habit;
            Options = options;
            TimeTheDay = timeTheDay;
            WeekDays = weekDays;
            NumberDayOfTheMonth = numberDayOfTheMonth;
        }
        public TimeResetInterval(Habit habit, ResetIntervalOptions options, TimeOnly timeTheDay, WeekDays weekDays, int numberDayOfTheMonth)
            :this(Guid.NewGuid(),habit, options, timeTheDay, weekDays,numberDayOfTheMonth)
        {     
            
        }
        protected TimeResetInterval(Habit habit)
            : base(Guid.NewGuid(), "TimeResetInterval")
        {
            Habit = habit;
        }
    }
}
