using BookOfHabitsMicroservice.Application.Models.Base;

namespace BookOfHabitsMicroservice.Application.Models.Person
{
    public class UpdatePersonModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
    }
}
