using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabitsMicroservice.Application.Models.Card
{
    public class CreateCardModel : ICreateModel
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
