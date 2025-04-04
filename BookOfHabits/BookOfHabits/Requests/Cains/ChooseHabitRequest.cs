using System.ComponentModel.DataAnnotations;

namespace BookOfHabits.Requests.Cains
{
    public class ChooseHabitRequest
    {
        public Guid PersonId { get; init; }
        public Guid RoomId { get; init; }
        public Guid HabitId { get; init; }
        public int CostOfWinning { get; init; }
    }
}
