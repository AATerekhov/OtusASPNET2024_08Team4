using BookOfHabitsMicroservice.Application.Models.Person;

namespace BookOfHabits.Responses.Room
{
    public class RoomShortResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required DateTime CreateDate { get; init; }
        public required DateTime UpdateDate { get; init; }
        public bool IsActive { get; init; }
    }
}
