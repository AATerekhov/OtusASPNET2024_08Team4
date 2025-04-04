using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;
using BookOfHabitsMicroservice.Domain.Entity.Exceptions;
using System.Runtime.CompilerServices;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class TimeResetInterval : Property
    {
        readonly int _ticksSec = 10_000_000;
        readonly int _day = 86_400;
        readonly int _daysInMonth = 31;
        //public Habit Habit { get; }
        public ResetIntervalOptions Options { get; private set; }
        public int TimeTheDay  { get; private set; }
        public WeekDays WeekDays { get; private set; }
        public int NumberDayOfTheMonth { get; private set; }

        public TimeResetInterval(Guid id, ResetIntervalOptions options, int timeTheDay, WeekDays weekDays, int numberDayOfTheMonth)
            :base(id, "TimeResetInterval")
        {
            SetProperty(options, timeTheDay, weekDays, numberDayOfTheMonth);
        }
        public TimeResetInterval(ResetIntervalOptions options, int timeTheDay, WeekDays weekDays, int numberDayOfTheMonth)
            :this(Guid.NewGuid(), options, timeTheDay, weekDays,numberDayOfTheMonth)
        {     
            
        }
        protected TimeResetInterval()
            : base(Guid.NewGuid(), "TimeResetInterval")
        {

        }
        public void SetProperty(ResetIntervalOptions options, int timeTheDay, WeekDays weekDays, int numberDayOfTheMonth)
        {
            Options = options;
            //if (timeTheDay > _day)
            //    throw new InvalidTimeResetIntervalException(timeTheDay);
            TimeTheDay = timeTheDay;
            WeekDays = weekDays;
            //if (numberDayOfTheMonth > _daysInMonth)
            //    throw new InvalidDayResetIntervalException(numberDayOfTheMonth);
            NumberDayOfTheMonth = numberDayOfTheMonth;
        }
        internal void Update(TimeResetInterval updateTimeResetInterval)
        {
            Options = updateTimeResetInterval.Options;
            TimeTheDay = updateTimeResetInterval.TimeTheDay;
            WeekDays = updateTimeResetInterval.WeekDays;
            NumberDayOfTheMonth = updateTimeResetInterval.NumberDayOfTheMonth;
        }
    }
}
