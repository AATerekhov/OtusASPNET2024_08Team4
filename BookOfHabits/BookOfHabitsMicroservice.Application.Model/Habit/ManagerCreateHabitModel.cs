namespace BookOfHabitsMicroservice.Application.Models.Habit
{
    public class ManagerCreateHabitModel
    {
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
