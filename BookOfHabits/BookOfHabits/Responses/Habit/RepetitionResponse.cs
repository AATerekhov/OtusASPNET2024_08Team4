namespace BookOfHabits.Responses.Habit
{
    public class RepetitionResponse
    {
        public Guid Id { get; init; }
        public int MaxCountPositive { get; init; }
        public int MaxCountNegative { get; init; }
        public bool IsLimit { get; init; }
        public int CountLimit { get; init; }
    }
}
