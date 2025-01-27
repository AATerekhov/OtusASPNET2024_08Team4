using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Responses.Habit
{
    public class HabitShortResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public bool IsUsed { get; init; }
        public HabitOptions Options { get; init; }
    }
}
