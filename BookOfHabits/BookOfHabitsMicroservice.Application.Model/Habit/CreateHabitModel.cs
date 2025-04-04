namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class CreateHabitModel
    {
        public Guid RoomId { get; init; }
        public Guid PersonId { get; init; }
        public Guid CardId { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
