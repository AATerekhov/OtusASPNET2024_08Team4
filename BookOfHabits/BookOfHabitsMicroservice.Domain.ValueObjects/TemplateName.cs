using BookOfHabitsMicroservice.Domain.ValueObjects.Base;

namespace BookOfHabitsMicroservice.Domain.ValueObjects
{
    public class TemplateName : KeyName
    {
        public TemplateName(string name) : base(name)
        {
        }
    }
}
