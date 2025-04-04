using BookOfHabitsMicroservice.Domain.Entity.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Domain.Entity.Propertys
{
    public class Repetition: Property
    {
        //public Habit Habit { get; }
        public int MaxCountPositive { get; private set; }
        public int MaxCountNegative { get; private set; }
        public bool IsLimit { get; private set; }
        public int CountLimit { get; private set; }

        public Repetition(Guid id, int maxCountPositive, int maxCountNegative, bool isLimit, int countLimit)
            :base(id, "Repetition")
        {
            SetProperty(maxCountPositive, maxCountNegative, isLimit, countLimit);
        }

        public Repetition(int maxCountPositive, int maxCountNegative, bool isLimit, int countLimit)
            :this(Guid.NewGuid(), maxCountPositive, maxCountNegative, isLimit, countLimit)
        {                
        }
        protected Repetition() : base(Guid.NewGuid(), "Repetition")
        {
            
        }
        public void SetProperty(int maxCountPositive, int maxCountNegative, bool isLimit, int countLimit) 
        {
            MaxCountPositive = maxCountPositive;
            MaxCountNegative = maxCountNegative;
            IsLimit = isLimit;
            CountLimit = countLimit;
        }
        internal void Update(Repetition updateRepetition)
        {
            MaxCountPositive = updateRepetition.MaxCountPositive;
            MaxCountNegative = updateRepetition.MaxCountNegative;
            IsLimit = updateRepetition.IsLimit;
            CountLimit = updateRepetition.CountLimit;
        }
    }
}
