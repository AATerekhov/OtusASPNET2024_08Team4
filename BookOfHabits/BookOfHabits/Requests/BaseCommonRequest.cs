namespace BookOfHabits.Requests
{
    public class BaseCommonRequest
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
