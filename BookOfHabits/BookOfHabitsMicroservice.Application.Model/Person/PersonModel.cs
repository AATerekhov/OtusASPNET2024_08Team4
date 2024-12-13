using BookOfHabitsMicroservice.Application.Models.Base;
using BookOfHabitsMicroservice.Application.Models.Habit;

namespace BookOfHabitsMicroservice.Application.Models.Person
{
    public class PersonModel : IModel<Guid>
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required IEnumerable<HabitModel> SuggestedHabits { get; init; }

    }
}
