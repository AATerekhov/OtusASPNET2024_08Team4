using BookOfHabitsMicroservice.Domain.ValueObjects.Base;

namespace BookOfHabitsMicroservice.Domain.ValueObjects
{
    public class PersonName : KeyName
    {
        public PersonName(string name) : base(name)
        {
        }
    }
}
