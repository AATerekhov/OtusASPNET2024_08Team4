namespace BookOfHabits.Requests.Person
{
    public class CreatePersonRequest
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
