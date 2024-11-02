using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Requests.Habit
{
    public class CreateHabitRequest: BaseCommonRequest
    {
        public Guid RoomId { get; set; }
        public Guid PersonId { get; set; }
    }
}
