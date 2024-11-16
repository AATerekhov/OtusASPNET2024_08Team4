namespace BookOfHabits.Requests.Person
{
    public class UpdatePersonRequest
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
    }
}
