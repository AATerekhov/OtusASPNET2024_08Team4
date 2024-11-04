using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Application.Models.Card
{
    public class UpdateCardModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public CardOptions Options { get; init; }
        public byte[]? Image { get; init; }
        public required string[] TitleCheckElements { get; init; }
    }
}
