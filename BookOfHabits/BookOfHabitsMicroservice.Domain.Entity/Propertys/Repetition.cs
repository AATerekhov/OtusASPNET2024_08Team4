using BookOfHabitsMicroservice.Domain.Entity.Base;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class Repetition: Property
    {
        public Habit Habit { get; }
        public int MaxCountPositive { get; }
        public int MaxCountNegative { get; }
        public bool IsLimit { get; }
        public int CountLimit { get; }

        public Repetition(Guid id,Habit habit, int maxCountPositive, int maxCountNegative, bool isLimit, int countLimit)
            :base(id, "Repetition")
        {
            Habit = habit;
            MaxCountPositive = maxCountPositive;
            MaxCountNegative = maxCountNegative;
            IsLimit = isLimit;
            CountLimit = countLimit;
        }

        public Repetition(Habit habit, int maxCountPositive, int maxCountNegative, bool isLimit, int countLimit)
            :this(Guid.NewGuid(), habit, maxCountPositive, maxCountNegative, isLimit, countLimit)
        {                
        }
        protected Repetition(Habit habit) : base(Guid.NewGuid(), "Repetition")
        {
            Habit = habit;   
        }
    }
}
