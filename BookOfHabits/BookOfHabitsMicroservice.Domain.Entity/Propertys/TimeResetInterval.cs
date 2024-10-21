using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class TimeResetInterval : Property
    {
        public Habit Habit { get; }
        public bool IsEveryDay { get; }
        public TimeOnly TimeTheDay  { get; }
        public bool IsWeekday { get; }
        public WeekDays WeekDays { get; }
        public bool IsOnceAMonth { get; }
        public int NumberDayOfTheMonth { get; }

        public TimeResetInterval(Guid id,Habit habit, bool isEveryDay, TimeOnly timeTheDay, bool isWeekday, WeekDays weekDays, bool isOnceAMonth, int numberDayOfTheMonth)
            :base(id, "TimeResetInterval")
        {
            Habit = habit;
            IsEveryDay = isEveryDay;
            TimeTheDay = timeTheDay;
            IsWeekday = isWeekday;
            WeekDays = weekDays;
            IsOnceAMonth = isOnceAMonth;
            NumberDayOfTheMonth = numberDayOfTheMonth;
        }
        public TimeResetInterval(Habit habit, bool isEveryDay, TimeOnly timeTheDay, bool isWeekday, WeekDays weekDays, bool isOnceAMonth, int numberDayOfTheMonth)
            :this(Guid.NewGuid(),habit, isEveryDay, timeTheDay, isWeekday, weekDays,isOnceAMonth,numberDayOfTheMonth)
        {                
        }
        protected TimeResetInterval(Habit habit)
            : base(Guid.NewGuid(), "TimeResetInterval")
        {
            Habit = habit;
        }

    }
}
