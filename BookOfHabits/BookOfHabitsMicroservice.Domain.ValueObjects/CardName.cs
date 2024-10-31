using BookOfHabitsMicroservice.Domain.ValueObjects.Base;

namespace BookOfHabitsMicroservice.Domain.ValueObjects
{
    public class CardName : KeyName
    {
        public CardName(string name) : base(name)
        {
        }
    }
}
