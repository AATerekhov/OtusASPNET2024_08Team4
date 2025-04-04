using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Application.Models.Card
{
    public class CardModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public CardOptions Options { get; init; }
        public required TemplateValuesModel TemplateValues { get; init; }
        public byte[]? Image { get; init; }
        public string[]? Status { get; init; }
        public string[]? TitleCheckElements { get; init; }
        public string[]? Tags { get; init; }
    }
}
