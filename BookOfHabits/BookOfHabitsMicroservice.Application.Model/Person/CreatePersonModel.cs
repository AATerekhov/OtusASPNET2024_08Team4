using BookOfHabitsMicroservice.Application.Models.Base;

namespace BookOfHabitsMicroservice.Application.Models.Person
{
    public class CreatePersonModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
    }
}
