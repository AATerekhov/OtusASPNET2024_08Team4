using BookOfHabitsMicroservice.Domain.ValueObjects.Base;

namespace BookOfHabitsMicroservice.Domain.ValueObjects
{
    public class HabitName: KeyName
    {
        public HabitName(string name):base(name)
        {
        }
    }
}
