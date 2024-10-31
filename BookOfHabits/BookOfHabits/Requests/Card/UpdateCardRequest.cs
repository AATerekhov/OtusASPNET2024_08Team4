using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Card
{
    public class UpdateCardRequest
    {
        public string? Name { get; init; }
        public string? Description { get; init; }
        public CardOptions Options { get; init; }
        public byte[]? Image { get; init; }
        public string[]? TitleCheckElements { get; init; }
    }
}
