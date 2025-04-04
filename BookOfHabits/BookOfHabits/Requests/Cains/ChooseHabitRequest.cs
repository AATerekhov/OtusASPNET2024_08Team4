using System.ComponentModel.DataAnnotations;

namespace BookOfHabits.Requests.Cains
{
    public class ChooseHabitRequest
    {
        public Guid PersonId { get; init; }
        public Guid RoomId { get; init; }
        public Guid HabitId { get; init; }
        [Required]
        public required string Description { get; init; }
    }
}
