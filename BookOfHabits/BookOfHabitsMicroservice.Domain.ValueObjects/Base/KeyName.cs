namespace BookOfHabitsMicroservice.Domain.ValueObjects.Base
{
    public abstract class KeyName : IEquatable<KeyName>, IEquatable<string>
    {
        public string Name { get; }
        protected KeyName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));
            if (name.Length > 50)
                throw new ArgumentOutOfRangeException(nameof(name), "Name must have less than 50 symbols");
            //if (name.Any(c => !(char.IsLetter(c) || char.IsWhiteSpace(c))))
                //throw new ArgumentException("Name must contain only letters or whitespaces", nameof(name));
            if (name.Count(с => char.IsWhiteSpace(с)) > 5)
                throw new ArgumentException("Name must contain less than 5 whitespaces", nameof(name));
            if (name.Contains("  "))
                throw new ArgumentException("Name must not contain double whitespaces", nameof(name));
            Name = name;
        }

        public bool Equals(KeyName? other) => other is not null && EqualityComparer<string>.Default.Equals(Name, other.Name);
        public bool Equals(string? other) => other is not null && EqualityComparer<string>.Default.Equals(Name, other);
        public override bool Equals(object? obj) => obj is KeyName other && EqualityComparer<string>.Default.Equals(Name, other.Name);
        public override int GetHashCode() => EqualityComparer<string>.Default.GetHashCode(Name);
        public override string ToString() => Name;
        public static bool operator ==(KeyName first, KeyName second)
        {
            if (ReferenceEquals(first, second))
                return true;
            return !first.Name.Equals(default) && first.Equals(second);
        }
        public static bool operator ==(string first, KeyName second) => !second.Name.Equals(default) && first.Equals(second.Name);
        public static bool operator ==(KeyName first, string second) => !first.Name.Equals(default) && first.Name.Equals(second);
        public static bool operator !=(KeyName first, KeyName second) => !(first == second);
        public static bool operator !=(string first, KeyName second) => !(first == second);
        public static bool operator !=(KeyName first, string second) => !(first == second);
    }
}
