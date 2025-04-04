namespace BookOfHabits.Requests.Habit
{
    public class RepetitionRequest
    {
        public int MaxCountPositive { get; init; }
        public int MaxCountNegative { get; init; }
        public bool IsLimit { get; init; }
        public int CountLimit { get; init; }
    }
}
