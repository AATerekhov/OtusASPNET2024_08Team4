using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Habit
{
    public class UpdateHabitRequest
    {
        public Guid Id { get; init; }
        public Guid PersonId { get; set; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public HabitOptions Options { get; init; }
    }
}
