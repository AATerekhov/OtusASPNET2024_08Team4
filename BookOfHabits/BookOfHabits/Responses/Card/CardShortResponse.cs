namespace BookOfHabits.Responses.Card
{
    public class CardShortResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
