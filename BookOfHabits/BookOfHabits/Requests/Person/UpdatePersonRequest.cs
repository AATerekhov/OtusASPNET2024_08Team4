namespace BookOfHabits.Requests.Person
{
    public class UpdatePersonRequest
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
