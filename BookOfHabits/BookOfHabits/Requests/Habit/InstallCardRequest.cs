namespace BookOfHabits.Requests.Habit
{
    public class InstallCardRequest
    {
        public Guid PersonId { get; init; }
        public Guid HabitId { get; init; }
        public Guid CardId { get; init; }
    }
}
