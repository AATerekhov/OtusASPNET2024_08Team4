using BookOfHabitsMicroservice.Application.Models.Card;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Responses.Card
{
    public class CardDetailedResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public CardOptions Options { get; init; }
        public required TemplateValuesResponse TemplateValues { get; init; }
        public required byte[] Image { get; init; }
        public required string[] Status { get; init; }
        public required string[] TitleCheckElements { get; init; }
        public required string[] Tags { get; init; }
    }
}
