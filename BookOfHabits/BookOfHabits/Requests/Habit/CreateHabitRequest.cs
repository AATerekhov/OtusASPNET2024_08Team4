using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Habit
{
    public class CreateHabitRequest
    {
        public Guid RoomId { get; set; }
        public Guid PersonId { get; set; }
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}
