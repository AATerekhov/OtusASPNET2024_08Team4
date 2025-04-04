using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Habit
{
    public class UpdateHabitRequest
    {
        public Guid Id { get; init; }
        public Guid PersonId { get; set; }
        public string? Name { get; init; }
        public string? Description { get; init; }
        public HabitOptions Options { get; init; }
        public DelayRequest? Delay { get; init; }
        public TimeResetIntervalRequest? TimeResetInterval { get; init; }
        public RepetitionRequest? Repetition { get; init; }
    }
}
