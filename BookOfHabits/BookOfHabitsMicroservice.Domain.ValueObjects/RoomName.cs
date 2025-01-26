namespace BookOfHabitsMicroservice.Domain.ValueObjects
{
    public class RoomName
    {
        public string Name { get; }
        public RoomName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (name.Length > 100)
                throw new ArgumentOutOfRangeException(nameof(name), "Name must have less than 100 symbols");
            //if (name.Any(c => !(char.IsLetter(c) || char.IsWhiteSpace(c))))
                //throw new ArgumentException("Name must contain only letters or whitespaces", nameof(name));
            if (name.Count(с => char.IsWhiteSpace(с)) > 10)
                throw new ArgumentException("Name must contain less than 10 words", nameof(name));
            if (name.Contains("  "))
                throw new ArgumentException("Name must not contain double whitespaces", nameof(name));
            Name = name;
        }
    }
}
