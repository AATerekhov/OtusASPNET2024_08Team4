namespace BookOfHabits.Responses.Habit
{
    public class DelayResponse
    {
        public Guid Id { get; init; }
        public bool IsAfterATime { get; init; }
        public int AfterTime { get; init; }
        public bool IsEndless { get; init; }
        public int DurationTime { get; init; }
    }
}
