using BookOfHabitsMicroservice.Domain.ValueObjects.Base;

namespace BookOfHabitsMicroservice.Domain.ValueObjects
{
    public class PersonName 
    {
        public string Name { get; }
        public PersonName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (name.Length > 50)
                throw new ArgumentOutOfRangeException(nameof(name), "Name must have less than 50 symbols");
            if (name.Count(с => char.IsWhiteSpace(с)) > 5)
                throw new ArgumentException("Name must contain less than 5 whitespaces", nameof(name));
            if (name.Contains("  "))
                throw new ArgumentException("Name must not contain double whitespaces", nameof(name));
            Name = name;
        }    
    }
}
