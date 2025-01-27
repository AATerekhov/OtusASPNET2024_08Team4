namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class InstallCardModel
    {
        public Guid PersonId { get; init; }
        public Guid HabitId { get; init; }
        public Guid CardId { get; init; }
    }
}
