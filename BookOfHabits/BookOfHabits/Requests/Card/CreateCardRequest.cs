using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Card
{
    public class CreateCardRequest: BaseCommonRequest
    {
        public CardOptions Options { get; init; }
        public byte[]? Image { get; init; }
        public required string[] TitleCheckElements { get; init; }
    }
}
