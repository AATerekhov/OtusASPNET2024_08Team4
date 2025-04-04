using BookOfHabits.Responses.Habit;
using BookOfHabits.Responses.Room;
using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Responses.Coins
{
    public class CoinsDetailedResponse
    {
        public Guid Id { get; init; }
        public Guid RoomId { get; init; }
        public required HabitFullDetailedResponse Habit { get; init; }
        public required RoomShortResponse Room { get; init; }
        public required string Description { get; init; }
        public CoinsOptions Options { get; init; }
        public int CostOfWinning { get; init; }
        public int Forfeit { get; init; }
        public int Start { get; init; }
        public int Falls { get; init; }
    }
}
