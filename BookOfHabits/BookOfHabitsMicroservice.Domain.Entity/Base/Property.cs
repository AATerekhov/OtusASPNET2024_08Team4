namespace BookOfHabitsMicroservice.Domain.Entity.Base
{
    public class Property(Guid id, string nameType):Entity<Guid>(id)
    {
        public string NameType { get; protected set; } = nameType;
    }
}
