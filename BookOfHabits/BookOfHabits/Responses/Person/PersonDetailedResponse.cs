using BookOfHabits.Responses.Habit;
using BookOfHabits.Responses.Room;

namespace BookOfHabits.Responses.Person
{
    public class PersonDetailedResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required IEnumerable<HabitShortResponse> SuggestedHabits { get; init; }
    }
}
