using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Card
{
    public class CreateCardRequest
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public CardOptions Options { get; init; }
        public byte[]? Image { get; init; }
        public string[]? TitleCheckElements { get; init; }
    }
}
