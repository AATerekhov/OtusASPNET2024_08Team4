using BookOfHabitsMicroservice.Domain.Entity.Base;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class Delay: Property
    {
        public Habit Habit { get; }
        public bool IsAfterATime { get; }
        public long AfterTime { get; }
        public DateTime Start { get; }
        public DateTime Finish { get; }
        public bool IsEndless { get; }
        public Delay(Guid id, Habit habit, bool isAfterATime, long afterTime, DateTime start, DateTime finish, bool isEndless) 
            : base(id, "Delay")
        {
            Habit = habit;
            IsAfterATime = isAfterATime;
            AfterTime = afterTime;
            Start = start;
            Finish = finish;
            IsEndless = isEndless;
        }
        public Delay(Habit habit, bool isAfterATime, long afterTime, DateTime start, DateTime finish, bool isEndless)
            :this(Guid.NewGuid(), habit, isAfterATime, afterTime, start, finish, isEndless)
        {                
        }
        protected Delay(Habit habit) : base(Guid.NewGuid(), "Delay")
        {
            Habit = habit;
        }
    }
}
