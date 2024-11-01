using BookOfHabitsMicroservice.Domain.Entity.Base;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class Delay: Property
    {
        readonly int _ticksSec = 10_000_000;
        readonly int _day = 86_400;
        //public Habit Habit { get; }
        public bool IsAfterATime { get; private set; }
        public int AfterTime { get; private set; }
        public bool IsEndless { get; private set; }
        public int DurationTime { get; private set; }
        public Delay(Guid id, bool isAfterATime, int afterTime, bool isEndless, int durationTime) 
            : base(id, "Delay")
        {
            IsAfterATime = isAfterATime;
            AfterTime = afterTime;
            IsEndless = isEndless;
            DurationTime = durationTime;
        }
        public Delay( bool isAfterATime, int afterTime, bool isEndless, int durationTime)
            :this(Guid.NewGuid(), isAfterATime, afterTime, isEndless, durationTime)
        {   
            
        }
        protected Delay() : base(Guid.NewGuid(), "Delay")
        {

        }
        public void SetIsAfterATime(bool isAfterATime) =>IsAfterATime = isAfterATime;
        public void SetAfterTime(int afterTime) => AfterTime = afterTime;
        public void SetIsEndless(bool isEndless) => IsEndless = isEndless;
        public void SetDurationTime(int durationTime) => DurationTime = durationTime;
    }
}
