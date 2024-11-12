using BookOfHabitsMicroservice.Domain.Entity.Enums;

namespace BookOfHabits.Responses.Coins
{
    public class CoinsShortResponse
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public required string Description { get; init; }
        public Guid RoomId { get; init; }
        public CoinsOptions Options { get; init; }
        public int CostOfWinning { get; init; }
        public int Forfeit { get; init; }
        public int Start { get; init; }
        public int Falls { get; init; }
    }
}
